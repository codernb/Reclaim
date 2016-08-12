using System;


namespace Assets.Scripts.Models.Map
{
    [Serializable]
    public class Map
    {

        private Tile[,] map;

        public Map(int size)
        {
            map = new Tile[size, size];
        }

    }
}
