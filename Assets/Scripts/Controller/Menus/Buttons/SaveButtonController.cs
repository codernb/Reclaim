using UnityEngine;
using UnityEngine.UI;

public class SaveButtonController : MonoBehaviour {

    public MapController mapController;
    public InputField inputField;
    public Button button;

	void Update() {
        inputField.interactable = mapController.isMapSet();
        button.interactable = inputField.text.Trim().Length > 0;
    }

    public void setMapName(string name)
    {
        inputField.text = name;
    }
	
}
