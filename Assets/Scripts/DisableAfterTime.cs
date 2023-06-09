using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    private float timeToDisable = 0.8f;
    private float timer;

    void OnEnable()
    {
        timer = timeToDisable;
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
