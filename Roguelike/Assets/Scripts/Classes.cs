/*
 * �ߺ��Ǵ� �ڵ带 �ִ��� ���̱� ���ؼ� �ߺ��Ǵ� �κ��� Ŭ������ ���� �� ��ũ��Ʈ�� �����߽��ϴ�.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base Ű����: ��� �ް��ִ� Ŭ������ ��Ī

public class Enemy : MonoBehaviour
{
    #region �� �ɷ�ġ
    protected int hit_point;
    protected int attack_damage;
    protected float attack_delay;
    protected float bullet_speed;
    protected float detect_range;
    protected bool can_fire;
    #endregion

    protected GameObject player;

    protected void EnemyStart()
    {
        player = GameObject.Find("Player");
    }

    protected void EnemyUpdate()
    {
        SetLeftRight();
    }

    void SetLeftRight()
    {
        if (transform.position.x > player.transform.position.x) //this.transform.position.x ����ϴ� Ŭ�������� this Ű���带 ���� Null Reference Exception �߻�
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    protected void EnemyFixedUpdate()
    {
        FireRay();
    }

    void FireRay()
    {
        LayerMask mask = LayerMask.GetMask("Player") | LayerMask.GetMask("Object") | LayerMask.GetMask("Wall");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, detect_range, mask);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player") == true)
            can_fire = true;
        else
            can_fire = false;
    }
}

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D rigidbody2d;

    protected int speed;
    protected float remove_time;

    protected void BulletStart()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        StartCoroutine("RemoveBullet");
    }

    IEnumerator RemoveBullet()
    {
        yield return new WaitForSeconds(remove_time);
        Destroy(this.gameObject);
    }

    protected void BulletUpdate()
    {

    }

    protected void BulletFixedUpdate()
    {
        rigidbody2d.velocity = transform.right * speed;
    }

    protected void BulletOnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Object"))
            Destroy(this.gameObject);
    }
}