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

        public string name = "Empty Tile";
        public List<Human> humans = new List<Human>();
        public List<Zombie> zombies = new List<Zombie>();
        public List<Item> items = new List<Item>();
        public Building building;

    }
}