using UnityEngine;
using Assets.Scripts.Models.Map;
using UnityEngine.UI;
using Assets.Scripts.Utils;
using System.Collections.Generic;
using Assets.Scripts.Models.Humans;

public class HumanMenuController : MonoBehaviour
{

    public Text counter;
    public PrefabStore prefabStore;
    public Transform content;

    private Tile tile;
    private Dictionary<Human, GameObject> cards = new Dictionary<Human, GameObject>();

    public void showHumans(Tile tile)
    {
        this.tile = tile;
        gameObject.GetComponent<Canvas>().enabled = true;
        counter.text = tile.humans.Count.ToString();
        setHumans(tile.humans);
    }

    private void setHumans(List<Human> humans)
    {
        foreach (var human in humans)
            instantiate(human);
        resize();
    }

    private void instantiate(Human human)
    {
        var humanCard = (GameObject)Instantiate(prefabStore.HumanNameCard, content);
        humanCard.GetComponentInChildren<Text>().text = human.getName();
        cards[human] = humanCard;
    }

    public void close()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void addNewHuman()
    {
        var human = HumanStore.getDefault();
        instantiate(human);
        tile.humans.Add(human);
        resize();
    }

    public void delete(Human human)
    {
        Destroy(cards[human]);
        cards.Remove(human);
        resize();
    }

    private void resize()
    {
        var rectTransform = content.GetComponent<RectTransform>();
        var size = rectTransform.sizeDelta;
        size.y = cards.Count * prefabStore.HumanNameCard.GetComponent<RectTransform>().sizeDelta.y;
        rectTransform.sizeDelta = size;
    }

}
