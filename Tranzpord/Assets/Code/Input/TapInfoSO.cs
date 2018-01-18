using UnityEngine;

[CreateAssetMenu(menuName = "Globals/Tap info")]
public class TapInfoSO : ScriptableObject
{
    public Vector3 TapPoint = new Vector3();
    public GameObject TappedObj = null;
    public bool TappedOnUI = false;

    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        TapPoint = Vector3.zero;
        TappedObj = null;
        TappedOnUI = false;
    }

    public Vector3Int GetIntTapCoord()
    {
        return Vector3Int.RoundToInt(TapPoint);
    }
}
