using UnityEngine.SceneManagement;
using UnityEngine;

public class CoreSceneController : MonoBehaviour {

    static CoreSceneController coreSceneController;

    public IntVariable ActiveScene;

    private int currentSceneId;
    private int nextSceneId;

    private AsyncOperation resourceUnloadTask;
    private AsyncOperation sceneLoadTask;
    private enum SceneState { Reset, Preload, Load, Unload, PostLoad, Ready, Run, Count };
    private SceneState sceneState;
    private delegate void UpdateDelegate();
    private UpdateDelegate[] updateDelegates;

    #region Public Static Methods
    public static void SwitchScene(int nextSceneIndex)
    {
        if (coreSceneController != null)
        {
            if (coreSceneController.currentSceneId != nextSceneIndex)
            {
                coreSceneController.nextSceneId = nextSceneIndex;
            }
        }
    }
    #endregion



    #region Protected Mono Methods
    protected void Awake()
    {
        Object.DontDestroyOnLoad(gameObject);
        coreSceneController = this;
        updateDelegates = new UpdateDelegate[(int)SceneState.Count];

        //Set each updateDelegate
        updateDelegates[(int)SceneState.Reset] = UpdateSceneReset;
        updateDelegates[(int)SceneState.Preload] = UpdateScenePreload;
        updateDelegates[(int)SceneState.Load] = UpdateSceneLoad;
        updateDelegates[(int)SceneState.Unload] = UpdateSceneUnload;
        updateDelegates[(int)SceneState.PostLoad] = UpdateScenePostLoad;
        updateDelegates[(int)SceneState.Ready] = UpdateSceneReady;
        updateDelegates[(int)SceneState.Run] = UpdateSceneRun;

        nextSceneId = ActiveScene.Value;

        sceneState = SceneState.Reset;
        //gameObject.GetComponent<Camera>().orthographicSize = Screen.height / 2;

    }

    protected void Start()
    {
        //gameObject.GetComponent<Camera>().enabled = false;
    }

    protected void OnDestroy()
    {
        //Clean Up all updateDelegates
        if (updateDelegates != null)
        {
            for (int i = 0; i < (int)SceneState.Count; i++)
            {
                updateDelegates[i] = null;
            }
            updateDelegates = null;
        }

        //Clean Up the singleton instance
        if (coreSceneController != null)
        {
            coreSceneController = null;
        }
    }


    protected void Update()
    {
        if (updateDelegates[(int)sceneState] != null)
        {
            updateDelegates[(int)sceneState]();
        }
    }
    #endregion



    #region Private Methods

    //Attach the new core controller to start cascade of loading
    private void UpdateSceneReset()
    {
        //run a gc pass
        System.GC.Collect();
        sceneState = SceneState.Preload;
    }


    //Handle anything that needs to happen before loading
    private void UpdateScenePreload()
    {
        sceneLoadTask = SceneManager.LoadSceneAsync((int)nextSceneId);
        sceneState = SceneState.Load;
    }


    //Show the loading Screen until it's loaded
    private void UpdateSceneLoad()
    {
        //done loading?
        if (sceneLoadTask.isDone == true)
        {
            sceneState = SceneState.Unload;
        }
        else
        {
            //Update scene loading progress
        }
    }


    //Clean Up unused resources by unloading them
    private void UpdateSceneUnload()
    {
        //cleaning up resources yet?
        if (resourceUnloadTask == null)
        {
            resourceUnloadTask = Resources.UnloadUnusedAssets();
        }
        else
        {
            //done cleaning up?
            if (resourceUnloadTask.isDone == true)
            {
                resourceUnloadTask = null;
                sceneState = SceneState.PostLoad;
            }
        }
    }


    //Handle anything that needs to happen immediately after loading
    private void UpdateScenePostLoad()
    {
        currentSceneId = nextSceneId;
        coreSceneController.ActiveScene.SetValue(currentSceneId);

        sceneState = SceneState.Ready;
    }


    //Handle anything that need to happen immediately after running
    private void UpdateSceneReady()
    {
        //run a gc pass
        //if I have assets loaded in the scene that are currently unused but may be used later
        //DON'T DO THIS HERE

        System.GC.Collect();
        sceneState = SceneState.Run;
    }


    //wait for scene change
    private void UpdateSceneRun()
    {
        if (currentSceneId != nextSceneId)
        {
            sceneState = SceneState.Reset;
        }
    }
    #endregion  
}
