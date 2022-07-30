using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public int speed;
    float horizontal, vertical;

    Rigidbody2D rigidbody2d;
    void Start()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rigidbody2d.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
