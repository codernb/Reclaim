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
        gameObject.SetActive(true);
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
        humanCard.GetComponent<HumanNameCardController>().humanMenuController = this;
    }

    public void close()
    {
        gameObject.SetActive(false);
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

    public void show(Human human)
    {

    }

    private void resize()
    {
        var rectTransform = content.GetComponent<RectTransform>();
        var size = rectTransform.sizeDelta;
        size.y = cards.Count * prefabStore.HumanNameCard.GetComponent<RectTransform>().sizeDelta.y;
        rectTransform.sizeDelta = size;
    }

}
