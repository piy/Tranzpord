using UnityEngine;

public class BackClickCatcher : MonoBehaviour {

    public GameEvent OnBackBtnPressed;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackBtnPressed.Raise();
        }
	}
}
