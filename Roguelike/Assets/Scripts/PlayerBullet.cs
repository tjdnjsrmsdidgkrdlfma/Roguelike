using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    float remove_time;
    float speed;

    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();

        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = transform.right * 10;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            Destroy(this.gameObject);
        if (other.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);
    }
}
