using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Models.Map;

public class BuildingMenuController : MonoBehaviour {

    public InputField nameField;

    private Tile tile;

    public void showBuilding(Tile tile)
    {
        this.tile = tile;
        gameObject.GetComponent<Canvas>().enabled = true;
        nameField.text = tile.building.getName();
    }

    public void setName(InputField name)
    {
        if (tile.building == null)
            return;
        tile.building.setName(name.text);
    }

    public void delete()
    {
        tile.building = null;
    }

} 
