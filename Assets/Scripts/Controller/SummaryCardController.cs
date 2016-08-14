using Assets.Scripts.Models.Buildings;
using UnityEngine;
using UnityEngine.UI;

public class SummaryCardController : MonoBehaviour {

    public InputField nameLabel;
    public GameObject newBuildingButton;

    private TileController tileController;

    public void setName(string name)
    {
        tileController.setName(name);
        nameLabel.text = name;
        CameraController.enableMovement(true);
    }

    public void setTileController(TileController tileController)
    {
        this.tileController = tileController;
        setName(tileController.getTile().name);
        newBuildingButton.SetActive(!isBuildingSet());
    }

    public void enableMovement(bool enable)
    {
        CameraController.enableMovement(enable);
    }

    public void openBuildingMenu()
    {
        BuildingMenuController.showBuilding(tileController.getTile());
    }

    public bool isBuildingSet()
    {
        return tileController.getTile().building != null;
    }

    public void newBuilding()
    {
        setBuilding(new Suburb());
    }

    public void setBuilding(Building building)
    {
        tileController.getTile().building = building;
    }

}
