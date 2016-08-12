using UnityEngine;
using Assets.Scripts.Models.Map;
using Assets.Scripts.Utils;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{

    public PrefabStore prefabStore;

    private Map map;
    private MapView mapView;
    private HashSet<TileController> selectedTileControllers = new HashSet<TileController>();

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            select();
        if (Input.GetKeyDown(KeyCode.Escape))
            clear();
    }

    public void newMap(int size)
    {
        selectedTileControllers = new HashSet<TileController>();
        if (map != null)
            Debug.Log("TODO: save map");
        map = new Map(size);
        if (mapView == null)
            mapView = new MapView(map.map, prefabStore);
        else
            mapView.clear(map.map);
    }

    private void select()
    {
        Debug.Log(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            var selectedTileController = hit.collider.gameObject.GetComponent<TileController>();
            if (selectedTileController == null)
            {
                clear();
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftControl))
                    clear();
                selectedTileController.selected(true);
                selectedTileControllers.Add(selectedTileController);
            }
        }
        else
        {
            clear();
        }
    }

    private void clear()
    {
        foreach (var tileController in selectedTileControllers)
            tileController.selected(false);
        selectedTileControllers.Clear();
    }

    private class MapView
    {
        private TileController[,] map;
        private PrefabStore prefabStore;

        public MapView(Tile[,] tiles, PrefabStore prefabStore)
        {
            this.prefabStore = prefabStore;
            initialize(tiles);
        }

        public void clear(Tile[,] tiles)
        {
            initialize(tiles, true);
        }

        private void initialize(Tile[,] tiles)
        {
            initialize(tiles, false);
        }

        private void initialize(Tile[,] tiles, bool clear)
        {
            var size = tiles.GetLength(0);
            var position = new Vector3();
            if (!clear)
                map = new TileController[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (clear)
                        map[i, j].clear();
                    var tileController = ((GameObject)Instantiate(prefabStore.Tile, position, Quaternion.identity)).GetComponent<TileController>();
                    map[i, j] = tileController;
                    position.z = j;
                }
                position.x = i;
            }
        }

    }

}
