using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base 키워드: 상속 받고있는 클래스를 지칭

public class Enemy : MonoBehaviour
{
    #region 적 능력치
    protected int hit_point;
    protected int attack_damage;
    protected float attack_delay;
    protected int bullet_number;
    protected float bullet_speed;
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
        if (transform.position.x > player.transform.position.x) //this.transform.position.x 상속하는 클래스에서 this 키워드를 쓰면 Null Reference Exception 발생
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}