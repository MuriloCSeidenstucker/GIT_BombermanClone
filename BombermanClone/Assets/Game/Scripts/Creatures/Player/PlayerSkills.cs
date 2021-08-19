using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    private int amountBombs;

    public int AmountBombs
    {
        get { return amountBombs; }
        private set { amountBombs = value; }
    }

    void Start()
    {
        AmountBombs = 1;
    }
}
