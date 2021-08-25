using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(PlayerSkills))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Bomb bombPrefab;

    CheckGridPosition playerPos;

    PlayerStatus playerStatus;
    PlayerSkills playerSkills;
    PlayerInput playerInput;
    Rigidbody2D rb;

    // Imperfect logic. It's necessary to improve.
    int bombsDropped;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        playerSkills = GetComponent<PlayerSkills>();
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();

        playerPos = FindObjectOfType(typeof(CheckGridPosition)) as CheckGridPosition;
    }

    void Update()
    {
        if (playerInput.GetActionInput())
        {
            if (!IsSkillLimitExceeded())
            {
                DropBomb();
            }
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
        Bomb newBomb = Instantiate(bombPrefab, playerPos.PositionInGrid(transform), transform.rotation);
        newBomb.OnExplode += BombExploded;
        bombsDropped++;
    }

    void BombExploded()
    {
        bombsDropped--;
    }

    bool IsSkillLimitExceeded()
    {
        if (bombsDropped == playerSkills.AmountBombs)
            return true;

        return false;
    }
}
