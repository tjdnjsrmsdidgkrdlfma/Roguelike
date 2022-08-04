using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public int speed;
    public int hitpoint = 6;
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
        Vector2 vector2;
        vector2.x = horizontal;
        vector2.y = vertical;
        rigidbody2d.velocity = vector2.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            hitpoint--;
            Debug.Log(hitpoint);
        }
    }
}
