using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assets.Scripts.Models
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