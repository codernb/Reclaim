using Assets.Scripts.Models.Map;
using UnityEngine;
using UnityEngine.UI;

public class ZombieMenuController : MonoBehaviour
{

    public Text counter;

    private Tile tile;

    public void showZombies(Tile tile)
    {
        this.tile = tile;
        gameObject.SetActive(true);
        counter.text = tile.zombies.Count.ToString();
    }

    public void close()
    {
        gameObject.SetActive(false);
    }

}
