using UnityEngine;
using UnityEngine.UI;

public class SaveButtonController : MonoBehaviour {

    public MapController mapController;
    public InputField inputField;
    public Button button;

	void Update() {
        inputField.interactable = mapController.isMapSet();
        var text = inputField.text;
        button.interactable = text != null && text.Trim().Length > 0;
    }
	
}
