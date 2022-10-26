using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int totalTiles;
    public int width;
    public int height;
    public Vector2 startPos;
    public Dictionary<Vector2, GameObject> tiles;
    public bool generateGrid;

    public Vector2 testSelectPos;
    public bool testSelect;

    // Start is called before the first frame update
    void Awake()
    {
        GenerateGrid(width, height);
    }

    private void LateUpdate()
    {
        // Editor testing buttons using bools
        if (generateGrid)
        {
            GenerateGrid(height,width);
            generateGrid = !generateGrid;
        }
        if(tiles != null)
        {
            totalTiles = tiles.Count;
        }

        // Test selected position
        if(testSelect)
        {
            testSelect = !testSelect;
            GenerateGrid(height, width);
            totalTiles = tiles.Count;
            SelectTile(testSelectPos);
        }

    }
    public void ClearGrid()
    {
        // Destroy children tiles
        if(transform.childCount > 0)
        {
            for(int i = transform.childCount - 1 ; i >= 0 ; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }



    }
    public void GenerateGrid(int w, int h)
    {
        // Clear any previous grid
        ClearGrid();
        // Tiles dictionary
        tiles = new Dictionary<Vector2, GameObject>();

        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                // Instantiate and position tiles centered in the grid
                var newTile = Instantiate(tilePrefab, new Vector3(i - w / 2, 0, j - h / 2), Quaternion.identity);
                // Name tile
                newTile.name = $"Tile {i + 1},{j + 1}";
                // Set gridmanager as parent
                newTile.transform.SetParent(this.transform);
                tiles.Add(new Vector2(i + 1, j + 1), newTile);
            }
        }
    }
    // Get tile in position x,y starting at 1
    public GameObject GetTile(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        else
        {
            return null;
        }
    }
    // Coloryze one tile
    public GameObject SelectTile(Vector2 pos)
    {

        if (tiles.TryGetValue(pos, out var tile))
        {
            tile.GetComponent<Tile>().SetColor(1);
            return tile;
        }
        else
        {
            return null;
        }
    }



}
