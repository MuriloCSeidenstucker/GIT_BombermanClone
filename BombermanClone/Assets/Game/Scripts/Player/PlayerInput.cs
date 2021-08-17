using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private struct PlayerInputConstants
    {
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
    }

    public Vector2 GetMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw(PlayerInputConstants.Horizontal);
        float verticalInput = Input.GetAxisRaw(PlayerInputConstants.Vertical);
        return new Vector2(horizontalInput, verticalInput);
    }
}
