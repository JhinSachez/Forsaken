using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector2 SpawnArea;
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject player;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<enemy>().setTarget(player);
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-SpawnArea.x, SpawnArea.x);
            position.y = SpawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-SpawnArea.y, SpawnArea.y);
            position.x = SpawnArea.x * f;
        }
        
        position.z = 0;





            return position;
        }
    }

