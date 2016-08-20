using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{

    public PrefabStore prefabStore;

    private List<GameObject> cards = new List<GameObject>();

    public void update(HashSet<TileController> selection)
    {
        clear();
        instantiate(selection);
        resize();
    }

    public void clear()
    {
        foreach (var card in cards)
            Destroy(card);
        cards.Clear();
        resize();
    }

    private void resize()
    {
        var rectTransform = GetComponent<RectTransform>();
        var size = rectTransform.sizeDelta;
        size.y = cards.Count * prefabStore.SummaryCard.GetComponent<RectTransform>().sizeDelta.y;
        rectTransform.sizeDelta = size;
    }

    private void instantiate(HashSet<TileController> selection)
    {
        foreach (var tileController in selection)
            instantiate(tileController);
    }

    private void instantiate(TileController tileController)
    {
        var card = (GameObject)Instantiate(prefabStore.SummaryCard, transform);
        card.GetComponent<SummaryCardController>().setTileController(tileController);
        cards.Add(card);
    }

}
