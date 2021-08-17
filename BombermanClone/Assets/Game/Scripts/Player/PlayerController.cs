using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    
    Rigidbody2D rb;
    Vector2 direction;
    float horizontalInput, verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        direction = new Vector2(horizontalInput, verticalInput);
        rb.velocity = direction * Time.fixedDeltaTime * speed;
    }
}
