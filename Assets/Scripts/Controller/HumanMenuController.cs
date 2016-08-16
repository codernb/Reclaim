using UnityEngine;
using Assets.Scripts.Models.Map;
using UnityEngine.UI;

public class HumanMenuController : MonoBehaviour
{

    public Text counter;

    private Tile tile;

    public void showHumans(Tile tile)
    {
        this.tile = tile;
        gameObject.GetComponent<Canvas>().enabled = true;
        counter.text = tile.humans.Count.ToString();
    }

}
