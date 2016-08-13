using UnityEngine;
using Assets.Scripts.Models.Map;
using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{

    public PrefabStore prefabStore;
    public SelectionController selectionController;

    private Map map;
    private MapView mapView;
    private HashSet<TileController> selectedTileControllers = new HashSet<TileController>();

    void Update()
    {
        if (Input.mousePosition.x < 200)
            return;
        if (Input.GetKey(KeyCode.Mouse0))
            select();
        if (Input.GetKeyDown(KeyCode.Escape))
            clear();
    }

    public void newMap(int size)
    {
        if (map != null)
            Debug.Log("TODO: save map");
        setMap(new Map(size));
    }

    public void setMap(Map newMap)
    {
        selectedTileControllers = new HashSet<TileController>();
        map = newMap;
        if (mapView == null)
            mapView = new MapView(map.map, prefabStore);
        else
            mapView.clear(map.map);
    }

    public bool isMapSet()
    {
        return map != null;
    }

    private void select()
    {
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
                else if (selectedTileControllers.Contains(selectedTileController))
                    return;
                selectedTileController.selected(true);
                selectedTileControllers.Add(selectedTileController);
                selectionController.update(selectedTileControllers);
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
        selectionController.clear();
    }

    public void setName(InputField nameField)
    {
        map.name = nameField.text;
    }

    public string getName()
    {
        return map.name;
    }

    public string[] getMapNames()
    {
        return MapReader.getMapNames();
    }

    public void load(Text nameField)
    {
        setMap(MapReader.load(nameField.text));
    }

    public void save()
    {
        if (map.name == null || map.name.Length == 0)
            return;
        MapWriter.save(map);
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
                    tileController.setName(i + " " + j);
                    map[i, j] = tileController;
                    position.z = j;
                }
                position.x = i;
            }
        }

    }

}
