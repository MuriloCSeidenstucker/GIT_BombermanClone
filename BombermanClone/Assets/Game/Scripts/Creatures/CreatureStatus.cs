using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStatus : MonoBehaviour
{
    private float speed;

    public float Speed
    {
        get { return speed; }
        protected set { speed = value; }
    }
}
