using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGridPosition : MonoBehaviour
{
    GridLayout gridLayout;

    float offsetToCenter = 0.5f;

    void Start()
    {
        gridLayout = transform.parent.GetComponentInParent<GridLayout>();
    }

    public Vector3 GridPosition(Transform thing)
    {
        Vector3Int thingPositionInGrid = gridLayout.WorldToCell(thing.position);
        Vector3 calculedPosition = new Vector3(thingPositionInGrid.x + offsetToCenter, thingPositionInGrid.y + offsetToCenter, thingPositionInGrid.z);
        return calculedPosition;
    }
}
