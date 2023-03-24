using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    private Vector2Int currentTilePosition;
    private Vector2Int currentPlayerTilePosition = new Vector2Int(0,0);
    private GameObject[,] terraintiles;
    private Vector2Int onTileGridPlayerPosition;

    [SerializeField] private Vector2Int playerTilePosition;
    [SerializeField] private float tileSize = 20f;
    [SerializeField] private int terraintilesHorizontalCount;
    [SerializeField] private int terraintilesVerticalCount;
    [SerializeField] private int fielvofVisionHeight = 3;
    [SerializeField] private int fieldofVisionWidth = 3;

    private void Awake()
    {
        terraintiles = new GameObject[terraintilesHorizontalCount, terraintilesVerticalCount];
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0; 
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

            


        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPosition.x = UpdateOnTileGridPlayerPosition(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y = UpdateOnTileGridPlayerPosition(onTileGridPlayerPosition.y, false);

            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for (int pov_x = -(fieldofVisionWidth/2); pov_x <= fieldofVisionWidth/2; pov_x++)
        {
            for (int pov_y = -(fielvofVisionHeight); pov_y <= fielvofVisionHeight/2; pov_y++)
            {
                int tileToUpdate_x = UpdateOnTileGridPlayerPosition(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = UpdateOnTileGridPlayerPosition(playerTilePosition.y + pov_y, false);

                GameObject tile = terraintiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(playerTilePosition.x + pov_x, playerTilePosition.y + pov_y);
            }
        }
    
    }

    public Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int UpdateOnTileGridPlayerPosition(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terraintilesHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terraintilesHorizontalCount - 1 + currentValue % terraintilesHorizontalCount ;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terraintilesVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terraintilesVerticalCount - 1 + currentValue % terraintilesVerticalCount ;
            }
        }

        return (int)currentValue;
    }

    public void Add(GameObject tilegameObject, Vector2Int tilePosition)
    {
        terraintiles[tilePosition.x, tilePosition.y] = tilegameObject;
    }
}
