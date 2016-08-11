using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour
{

    private Color originalColor;
    private bool isSelected;

    public void clear()
    {
        Destroy(gameObject);
    }

    public void selected(bool select)
    {
        if (select)
        {
            if (isSelected)
                return;
            originalColor = gameObject.GetComponent<MeshRenderer>().material.color;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            isSelected = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = originalColor;
            isSelected = false;
        }
    }

}
