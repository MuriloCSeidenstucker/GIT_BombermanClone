using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public event Action OnExplode;

    float timeToExplode = 2.0f;

    void Start()
    {
        StartCoroutine(BombSettings());
    }

    IEnumerator BombSettings()
    {
        yield return new WaitForSeconds(timeToExplode);
        if (OnExplode != null)
        {
            OnExplode.Invoke();
        }
        Destroy(gameObject);
    }
}
