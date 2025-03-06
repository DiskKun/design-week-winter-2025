using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ObjectManager : MonoBehaviour
{
    public Tilemap tilemap;
    
    
    public int fishbowlState;
    public int foodState;
    public int stoveState;
    public int sinkState;
    public int windowState;
    public int potState;

    public TileBase[] fishbowlTiles = new TileBase[3];
    public TileBase[] foodTiles = new TileBase[3];
    public TileBase[] stoveTiles = new TileBase[3];
    public TileBase[] sinkTiles = new TileBase[3];
    public TileBase[] windowTiles = new TileBase[3];
    public TileBase[] potTiles = new TileBase[4];

    



    Vector3Int[] tilePositions = {
            // Fishbowl 0
            new Vector3Int(-9, -7, 1),
            // Food 1
            new Vector3Int(2, -4, 2),
            // Sink 2
            new Vector3Int(-7, 5, 1),
            // Stove 3
            new Vector3Int(4, 5, 1),
            // Window 4
            new Vector3Int(5, -4, 1),
            // Pot 5
            new Vector3Int(4, 5, 2)
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
            case "food":
                foodState = state;
                break;
            case "stove":
                stoveState = state;
                break;
            case "sink":
                sinkState = state;
                break;
            case "window":
                windowState = state;
                break;
            case "pot":
                potState = state;
                break;
        }
    }

    public int GetState(string stateName)
    {
        switch (stateName)
        {
            case "fishbowl":
                return fishbowlState;
            case "food":
                return foodState;
            case "stove":
                return stoveState;
            case "sink":
                return sinkState;
            case "window":
                return windowState;
            case "pot":
                return potState;
        }
        return 100;
    }

    void UpdateTiles()
    {
        tilemap.SetTile(tilePositions[0], fishbowlTiles[fishbowlState]);
        tilemap.SetTile(tilePositions[1], foodTiles[foodState]);
        tilemap.SetTile(tilePositions[2], sinkTiles[sinkState]);
        tilemap.SetTile(tilePositions[3], stoveTiles[stoveState]);
        tilemap.SetTile(tilePositions[4], windowTiles[windowState]);
        tilemap.SetTile(tilePositions[5], potTiles[potState]);
    }
}
