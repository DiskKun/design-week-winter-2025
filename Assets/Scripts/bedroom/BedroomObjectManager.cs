using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BedroomObjectManager : MonoBehaviour
{
    public Tilemap tilemap;


    public int roseState;
    public int toolkitState;
    public int bedState;
    public int lampState;
    public int curtainState;
    public int clockState;
    public int playmatState;
    public int exitstarState;

    public TileBase[] roseTiles = new TileBase[4];
    public TileBase[] toolkitTiles = new TileBase[3];
    public TileBase[] bedTiles = new TileBase[3];
    public TileBase[] lampTiles = new TileBase[3];
    public TileBase[] curtainTiles = new TileBase[3];
    public TileBase[] clockTiles = new TileBase[3];
    public TileBase[] playmatTiles = new TileBase[3];
    public TileBase[] exitstarTiles = new TileBase[2];

    public TileBase[] wallTiles;
    public GameObject kitchenCover;
    public Renderer door;




    Vector3Int[] tilePositions = {
            // Rose 0
            new Vector3Int(6, -23, 2),
            // Toolkit 1
            new Vector3Int(-10, -16, 2),
            // Bed 2
            new Vector3Int(-2, -10, 1),
            // Lamp 3
            new Vector3Int(-6, -23, 1),
            // Curtain 4
            new Vector3Int(7, -17, 1),
            // Clock 5
            new Vector3Int(5, -12, 2),
            // Playmat 6
            new Vector3Int(-9, -21, 1),
            // Exit star 7
            new Vector3Int(-2, -10, 2)
        };





    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTiles();
        if (door.isVisible)
        {
            kitchenCover.SetActive(true);
            tilemap.SetTile(new Vector3Int(-7, -8, 0), wallTiles[0]);
            tilemap.SetTile(new Vector3Int(-7, -9, 0), wallTiles[1]);
            door.gameObject.SetActive(false);
        }

    }

    public void SetState(string stateName, int state)
    {
        switch (stateName)
        {
            case "rose":
                roseState = state;
                break;
            case "toolkit":
                toolkitState = state;
                break;
            case "bed":
                bedState = state;
                break;
            case "lamp":
                lampState = state;
                break;
            case "curtain":
                curtainState = state;
                break;
            case "clock":
                clockState = state;
                break;
            case "playmat":
                playmatState = state;
                break;
            case "exitstar":
                exitstarState = state;
                break;
        }
    }

    public int GetState(string stateName)
    {
        switch (stateName)
        {
            case "rose":
                return roseState;
            case "toolkit":
                return toolkitState;
            case "bed":
                return bedState;
            case "lamp":
                return lampState;
            case "curtain":
                return curtainState;
            case "clock":
                return clockState;
            case "playmat":
                return playmatState;
            case "exitstar":
                return exitstarState;
        }
        return 100;
    }

    void UpdateTiles()
    {
        tilemap.SetTile(tilePositions[0], roseTiles[roseState]);
        tilemap.SetTile(tilePositions[1], toolkitTiles[toolkitState]);
        tilemap.SetTile(tilePositions[2], bedTiles[bedState]);
        tilemap.SetTile(tilePositions[3], lampTiles[lampState]);
        tilemap.SetTile(tilePositions[4], curtainTiles[curtainState]);
        tilemap.SetTile(tilePositions[5], clockTiles[clockState]);
        tilemap.SetTile(tilePositions[6], playmatTiles[playmatState]);
        tilemap.SetTile(tilePositions[7], exitstarTiles[exitstarState]);
    }
}
