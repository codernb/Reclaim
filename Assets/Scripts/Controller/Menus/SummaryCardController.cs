using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

public class SummaryCardController : MonoBehaviour {

    public InputField nameLabel;
    public GameObject newBuildingButton;
    public Text humansButtonText;
    public Text zombiesButtonText;

    private TileController tileController;

    public void setName(string name)
    {
        tileController.setName(name);
        nameLabel.text = name;
        endEditText();
    }

    public void setTileController(TileController tileController)
    {
        this.tileController = tileController;
        setName(tileController.getTile().name);
        newBuildingButton.SetActive(!isBuildingSet());
        var tile = tileController.getTile();
        humansButtonText.text = tile.humans.Count.ToString() + " Humans";
        zombiesButtonText.text = tileController.getTile().zombies.Count.ToString() + " Zombies";
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

    public void enableCameraMovement(bool enable)
    {
        MenuController.enableCameraMovementS(enable);
    }

    public void openBuildingMenu()
    {
        MenuController.openBuildingMenuS(tileController.getTile());
    }

    public void openHumansMenu()
    {
        MenuController.openHumansMenuS(tileController.getTile());
    }

    public void openZombiesMenu()
    {
        MenuController.openZombiesMenuS(tileController.getTile());
    }

    public void startEditText()
    {
        MenuController.startEditTextS();
    }

    public void endEditText()
    {
        MenuController.endEditTextS();
    }

}
