using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 플레이어 능력치
    public int speed;
    public int hit_point;
    #endregion

    float horizontal, vertical;

    public bool stop_weapon_moving;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crosshair") == true)
            stop_weapon_moving = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crosshair") == true)
            stop_weapon_moving = false;
    }
}
