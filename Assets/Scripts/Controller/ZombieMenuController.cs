﻿using Assets.Scripts.Models.Map;
using UnityEngine;
using UnityEngine.UI;

public class ZombieMenuController : MonoBehaviour
{

    public Text counter;

    private Tile tile;

    public void showHumans(Tile tile)
    {
        this.tile = tile;
        gameObject.GetComponent<Canvas>().enabled = true;
        counter.text = tile.zombies.Count.ToString();
    }

}
