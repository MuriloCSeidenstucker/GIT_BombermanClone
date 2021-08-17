using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CreatureStatus
{
    public int AmountBombs { get; private set; }

    void Start()
    {
        Speed = 200;
    }
}
