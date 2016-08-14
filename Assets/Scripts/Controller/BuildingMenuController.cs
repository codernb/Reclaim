using UnityEngine;
using Assets.Scripts.Models.Buildings;
using UnityEngine.UI;

public class BuildingMenuController : MonoBehaviour {

    public new InputField name;

    private static GameObject staticGameObject;
    private static Building staticBuilding;

    public static void showBuilding(Building building)
    {
        staticGameObject.GetComponent<Canvas>().enabled = true;
        staticBuilding = building;
    }

    void Start()
    {
        staticGameObject = gameObject;
    }

    private void update()
    {
        name.text = staticBuilding.getName();
    }

    public void setName(InputField name)
    {
        if (staticBuilding == null)
            return;
        staticBuilding.setName(name.text);
    }

} 
