using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Models.Map;

public class BuildingMenuController : MonoBehaviour
{

    public InputField nameField;
    public Text integrityText;
    public Slider integritySlider;

    private Tile tile;

    public void showBuilding(Tile tile)
    {
        this.tile = tile;
        gameObject.GetComponent<Canvas>().enabled = true;
        nameField.text = tile.building.getName();
        integritySlider.value = tile.building.getIntegrity();
    }

    public void setName()
    {
        tile.building.setName(nameField.text);
    }

    public void setIntegrity()
    {
        integrityText.text = string.Format("{0:0.00}%", integritySlider.value * 100);
        tile.building.setIntegrity(integritySlider.value);
    }

    public void delete()
    {
        tile.building = null;
    }

    public void close()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

}
