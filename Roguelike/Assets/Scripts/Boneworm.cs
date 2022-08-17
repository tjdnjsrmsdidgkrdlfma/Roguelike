using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boneworm : Enemy
{
    public float detectrange;

    GameObject bullet_prefab;

    void Start()
    {
        detectrange = 10;

        bullet_prefab = Resources.Load("Prefabs/BonewormBullet") as GameObject;

        EnemyStart();
        SetStats();
        StartCoroutine("FireBullet");
    }

    void SetStats()
    {
        hit_point = 5;
        attack_damage = 1;
        attack_delay = 2.0f;
        detect_range = 10f;
        can_fire = false;
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            if (can_fire == true)
            {
                GameObject bullet = MonoBehaviour.Instantiate(bullet_prefab);
                bullet.transform.position = this.transform.position;
            }

            yield return new WaitForSeconds(attack_delay);
        }
    }

    void Update()
    {
        EnemyUpdate();
    }

    void FixedUpdate()
    {
        EnemyFixedUpdate();
    }

    //IEnumerator FireBullet()
    //{
    //    int i;

    //    while (true)
    //    {
    //        for (i = 0; i < bullet_number; i++)
    //        {
    //            GameObject bullet = MonoBehaviour.Instantiate(bullet_prefab);
    //            Rigidbody2D bullet_rigidbody = bullet.GetComponent<Rigidbody2D>();

    //            bullet.name = "bullet" + "_" + i;
    //            bullet.transform.position = this.transform.position;

    //            Vector3 dir = player.transform.position - this.transform.position;
    //            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    //            bullet_rigidbody.velocity = new Vector3(bullet_speed, 0, 0);
    //        }

    //        yield return new WaitForSeconds(3.0f);
    //    }
    //}
}
