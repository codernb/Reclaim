using System;


namespace Assets.Scripts.Models.Map
{
    [Serializable]
    public class Map
    {

        public string name;
        public Tile[,] tiles;

        public Map(int size)
        {
            tiles = new Tile[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    tiles[i, j] = new Tile();
        }

    }
}
