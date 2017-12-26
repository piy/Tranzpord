using UnityEngine;
using UnityEngine.UI;

public class UITextReplacer : MonoBehaviour {

    public IntReference Data;
    public Text TextField;

	
	void Start () {
        UpdateText();
	}

    public void UpdateText()
    {
        TextField.text = Data.Value.ToString();
    }
}
