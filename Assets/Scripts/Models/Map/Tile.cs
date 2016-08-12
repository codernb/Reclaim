using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Humans;
using Assets.Scripts.Models.Items;
using Assets.Scripts.Models.Zombies;
using System;
using System.Collections.Generic;


namespace Assets.Scripts.Models.Map
{
    [Serializable]
    public class Tile
    {

        public String name;
        public List<Human> humans;
        public List<Zombie> zombies;
        public List<Item> items;
        public Building building;

    }
}