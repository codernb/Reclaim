using UnityEngine;
using UnityEngine.UI;

public class SummaryCardController : MonoBehaviour {

    public InputField nameLabel;
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
        setName(tileController.tile.name);
    }

    public void enableMovement(bool enable)
    {
        CameraController.enableMovement(enable);
    }

}
