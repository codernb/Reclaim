using Assets.Scripts.Models.Humans;
using UnityEngine;

public class HumanNameCardController : MonoBehaviour {

    public Human human;
    public HumanMenuController humanMenuController;

    public void show()
    {
        humanMenuController.show(human);
    }

}
