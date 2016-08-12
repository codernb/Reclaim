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
            mapView = new MapView(size, prefabStore);
        else
            mapView.clear();
    }

    private void select()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                clear();
                selectedTileControllers.Clear();
            }
            var selectedTileController = hit.collider.gameObject.GetComponent<TileController>();
            if (selectedTileController == null)
            {
                clear();
            }
            else
            {
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
    }

    private class MapView
    {
        private TileController[,] map;
        private PrefabStore prefabStore;

        public MapView(int size, PrefabStore prefabStore)
        {
            this.prefabStore = prefabStore;
            initialize(size);
        }

        public void clear()
        {
            initialize(map.GetLength(0), true);
        }

        private void initialize(int size)
        {
            initialize(size, false);
        }

        private void initialize(int size, bool clear)
        {
            var position = new Vector3();
            if (!clear)
                map = new TileController[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (clear)
                        map[i, j].clear();
                    map[i, j] = ((GameObject)Instantiate(prefabStore.Tile, position, Quaternion.identity)).GetComponent<TileController>();
                    position.z = j;
                }
                position.x = i;
            }
        }

    }

}
