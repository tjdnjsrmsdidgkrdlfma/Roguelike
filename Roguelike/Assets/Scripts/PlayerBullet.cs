/*
 * �÷��̾ �߻��� �Ѿ��� �����ϴ� ��ũ��Ʈ�Դϴ�.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    void Start()
    {
        speed = 10;
        remove_time = 3f;
        BulletStart();
        RotateForwardMouse();
    }
    
    void RotateForwardMouse()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
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
        if (other.gameObject.CompareTag("Enemy"))
            Destroy(this.gameObject);
        BulletOnCollisionEnter2D(other);
    }
}
