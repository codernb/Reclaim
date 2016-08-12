using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Humans;
using Assets.Scripts.Models.Items;
using Assets.Scripts.Models.Zombies;
using System;
using System.Collections.Generic;


namespace Assets.Scripts.Models.Map
{
    [Serializable]
    class Tile
    {

        private List<Human> humans;
        private List<Zombie> zombies;
        private List<Item> items;
        private Building building;

    }
}