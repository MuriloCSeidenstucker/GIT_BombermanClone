using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    void Update()
    {
        
    }
}
