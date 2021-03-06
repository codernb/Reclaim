﻿using Assets.Scripts.Models.Map;
using UnityEngine;

public class TileController : MonoBehaviour
{

    private Tile tile;
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

    public void setTile(Tile tile)
    {
        this.tile = tile;
    }

    public Tile getTile()
    {
        return tile;
    }

    public string getName()
    {
        return tile.name;
    }

    public void setName(string name)
    {
        tile.name = name;
    }

}
