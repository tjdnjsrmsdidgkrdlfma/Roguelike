using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigidbody2d;

    float remove_time;
    float speed;

    void Start()
    {
        player = GameObject.Find("Player");
        rigidbody2d = this.GetComponent<Rigidbody2D>();

        Vector3 dir = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //rigidbody2d.velocity = new Vector3(1, 0, 0);
        rigidbody2d.velocity = transform.right * 10;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);
    }
}
