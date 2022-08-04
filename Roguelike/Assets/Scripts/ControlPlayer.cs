using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public int speed;
    public int hit_point;

    public int bullet_speed;

    float horizontal, vertical;

    Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
        FireBullet();
    }

    void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FireBullet()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            GameObject bullet_prefab = Resources.Load("Prefabs/PlayerBullet") as GameObject;
            GameObject bullet = MonoBehaviour.Instantiate(bullet_prefab);

            bullet.transform.position = this.transform.position;
        }
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

        }
    }
}
