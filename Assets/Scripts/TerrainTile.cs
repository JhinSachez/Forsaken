using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{

    [SerializeField] Vector2Int tilePosition;
    
    void Start()
    {
        GetComponentInParent<Background>().Add(gameObject, tilePosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
