using UnityEngine;
using Assets.Scripts.Models.Buildings;
using UnityEngine.UI;
using Assets.Scripts.Models.Map;

public class BuildingMenuController : MonoBehaviour {

    public new InputField name;

    private static GameObject staticGameObject;
    private static Tile staticTile;

    public static void showBuilding(Tile tile)
    {
        staticGameObject.GetComponent<Canvas>().enabled = true;
        staticTile = tile;
        staticGameObject.GetComponent<BuildingMenuController>().update();
    }

    void Start()
    {
        staticGameObject = gameObject;
    }

    private void update()
    {
        name.text = staticTile.building.getName();
    }

    public void setName(InputField name)
    {
        if (staticTile.building == null)
            return;
        staticTile.building.setName(name.text);
    }

    public void delete()
    {
        staticTile.building = null;
    }

} 
