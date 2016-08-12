using UnityEngine;
using UnityEngine.UI;

public class SummaryCardController : MonoBehaviour {

    public Text nameLabel;
    public TileController tile;

    void Update()
    {
        nameLabel.text = tile.getName();
    }

}
