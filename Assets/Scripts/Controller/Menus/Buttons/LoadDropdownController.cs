using UnityEngine;
using UnityEngine.UI;

public class LoadDropdownController : MonoBehaviour
{

    public MapController mapController;
    public Dropdown dropdown;

    void Update()
    {
        var mapNames = mapController.getMapNames();
        if (mapNames.Length == dropdown.options.Count)
            return;
        dropdown.options.Clear();
        foreach (var mapName in mapNames)
            dropdown.options.Add(new Dropdown.OptionData() { text = mapName });
        dropdown.captionText.text = mapNames[0];
    }

}
