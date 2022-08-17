using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBullet : Bullet
{
    GameObject player;

    void Start()
    {
        speed = 10;
        remove_time = 3f;
        player = GameObject.Find("Player");
        BulletStart();
        RotateForwardPlayer();
    }

    void RotateForwardPlayer()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        BulletFixedUpdate();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);
        BulletOnCollisionEnter2D(other);
    }
}
