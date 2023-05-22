using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;
    public void GameOvers()
    {
        Debug.Log("Game over");
        GetComponent<Movement>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
    }
}
