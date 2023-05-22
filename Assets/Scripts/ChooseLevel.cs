using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public void LevelSelector()
        {
            SceneManager.LoadScene("LevelSelector");
        }
    
}
