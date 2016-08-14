﻿using UnityEngine;
using Assets.Scripts.Models.Map;
using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{

    public PrefabStore prefabStore;
    public SelectionController selectionController;
    public SaveButtonController saveButtonController;

    private Map map;
    private HashSet<TileController> tileControllers = new HashSet<TileController>();
    private HashSet<TileController> selectedTileControllers = new HashSet<TileController>();

    void Update()
    {
        if (Input.mousePosition.x < 200)
            return;
        if (Input.GetKey(KeyCode.Mouse0))
            select();
        if (Input.GetKeyDown(KeyCode.Escape))
            clearSelection();
    }

    public void newMap(int size)
    {
        if (map != null)
            Debug.Log("TODO: ask to save map");
        setMap(new Map(size));
    }

    public void setMap(Map newMap)
    {
        saveButtonController.setMapName(newMap.name);
        instantiateMap(newMap);
        map = newMap;
    }

    private void instantiateMap(Map map)
    {
        clear();
        instantiateTiles(map);
    }

    private void clear()
    {
        foreach (var tileController in tileControllers)
            Destroy(tileController.gameObject);
        tileControllers.Clear();
        selectedTileControllers.Clear();
        selectionController.update(selectedTileControllers);
    }

    private void instantiateTiles(Map map)
    {
        var size = map.tiles.GetLength(0);
        var position = new Vector3();
        for (int i = 0; i < size; i++)
        {
            position.x = i;
            for (int j = 0; j < size; j++)
            {
                position.z = j;
                var tileController = ((GameObject)Instantiate(prefabStore.Tile, position, Quaternion.identity, transform)).GetComponent<TileController>();
                tileController.setTile(map.tiles[i, j]);
                tileControllers.Add(tileController);
            }
        }
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
                clearSelection();
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftControl))
                    clearSelection();
                else if (selectedTileControllers.Contains(selectedTileController))
                    return;
                selectedTileController.selected(true);
                selectedTileControllers.Add(selectedTileController);
                selectionController.update(selectedTileControllers);
            }
        }
        else
        {
            clearSelection();
        }
    }

    private void clearSelection()
    {
        foreach (var tileController in selectedTileControllers)
            tileController.selected(false);
        selectedTileControllers.Clear();
        selectionController.clear();
    }

    public void setName(InputField nameField)
    {
        if (map == null || nameField.text.Trim().Length == 0)
            return;
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

}
