using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    GameObject player;
    GameObject bullet_prefab;

    public int bullet_speed;

    void Start()
    {
        player = GameObject.Find("Player");
        bullet_prefab = Resources.Load("Prefabs/Bullet") as GameObject;
        StartCoroutine("FireBullet");
    }

    void Update()
    {
        SetLeftRight();
    }

    void SetLeftRight()
    {
        if (this.transform.position.x > player.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    IEnumerator FireBullet()
    {
        int i = 0;

        while(true)
        {
            GameObject bullet = MonoBehaviour.Instantiate(bullet_prefab);
            Rigidbody2D bullet_rigidbody = bullet.GetComponent<Rigidbody2D>();

            bullet.name = "Bullet" + "_" + i;
            bullet.transform.position = this.transform.position;

            Vector3 dir = player.transform.position - transform.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            bullet_rigidbody.velocity = new Vector3(bullet_speed, 0, 0);

            i++;

            yield return new WaitForSeconds(3.0f);
        }
    }
}
