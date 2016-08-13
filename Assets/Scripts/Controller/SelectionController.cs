using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{

    public PrefabStore prefabStore;

    private List<GameObject> cards = new List<GameObject>();

    public void update(HashSet<TileController> selection)
    {
        resize(selection.Count);
        clear();
        instantiate(selection);
    }

    private void resize(int count)
    {
        var rectTransform = GetComponent<RectTransform>();
        var size = rectTransform.sizeDelta;
        size.y = count * prefabStore.SummaryCard.GetComponent<RectTransform>().sizeDelta.y;
        rectTransform.sizeDelta = size;
    }

    public void clear()
    {
        foreach (var card in cards)
            Destroy(card);
        cards.Clear();
    }

    private void instantiate(HashSet<TileController> selection)
    {
        foreach (var tileController in selection)
        {
            var card = (GameObject)Instantiate(prefabStore.SummaryCard, transform);
            card.GetComponent<SummaryCardController>().tile = tileController;
            cards.Add(card);
        }
    }

}
