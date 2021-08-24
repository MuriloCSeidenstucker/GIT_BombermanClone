using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGridPosition : MonoBehaviour
{
    GridLayout gridLayout;
    Transform player;

    Vector3Int cellPosition;
    public Vector3Int CellPosition { get => cellPosition; private set => cellPosition = value; }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        gridLayout = transform.parent.GetComponentInParent<GridLayout>();
    }

    void FixedUpdate()
    {
        CellPosition = gridLayout.WorldToCell(player.position);
    }
}
