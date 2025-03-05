using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ObjectManager : MonoBehaviour
{
    public Tilemap tilemap;
    
    public int fishbowlState;
    public int fireplaceState;
    public int stoveState;
    public int sinkState;

    public TileBase[] fishbowlTiles = new TileBase[3];
    public TileBase[] fireplaceTiles = new TileBase[3];
    public TileBase[] stoveTiles = new TileBase[3];
    public TileBase[] sinkTiles = new TileBase[3];



    Vector3Int[] tilePositions = {
            // Fishbowl 0
            new Vector3Int(-4, 6, 1),
            // Fireplace 1
            new Vector3Int(2, 6, 0),
            // Sink 2
            new Vector3Int(-2, -6, 0),
            // Stove 3
            new Vector3Int(1, -6, 0)
        };



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTiles();
        
    }

    public void SetState(string stateName, int state)
    {
        switch (stateName)
        {
            case "fishbowl":
                fishbowlState = state;
                break;
            case "fireplace":
                fireplaceState = state;
                break;
            case "stove":
                stoveState = state;
                break;
            case "sink":
                sinkState = state;
                break;
        }
    }

    public int GetState(string stateName)
    {
        switch (stateName)
        {
            case "fishbowl":
                return fishbowlState;
            case "fireplace":
                return fireplaceState;
            case "stove":
                return stoveState;
            case "sink":
                return sinkState;
        }
        return 100;
    }

    void UpdateTiles()
    {
        tilemap.SetTile(tilePositions[0], fishbowlTiles[fishbowlState]);
        tilemap.SetTile(tilePositions[1], fireplaceTiles[fireplaceState]);
        tilemap.SetTile(tilePositions[2], sinkTiles[sinkState]);
        tilemap.SetTile(tilePositions[3], stoveTiles[stoveState]);

    }
}
