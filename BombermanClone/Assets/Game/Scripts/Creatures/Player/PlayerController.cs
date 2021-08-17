using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bomb;

    PlayerStatus playerStatus;
    PlayerInput playerInput;
    Rigidbody2D rb;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerInput.GetActionInput())
        {
            DropBomb();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = playerInput.GetMovementInput() * Time.fixedDeltaTime * playerStatus.Speed;
        rb.velocity = direction;
    }

    void DropBomb()
    {
        Instantiate(bomb, transform.position, transform.rotation);
    }
}
