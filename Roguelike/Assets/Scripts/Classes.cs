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
        if (transform.position.x > player.transform.position.x) //this.transform.position.x ����ϴ� Ŭ�������� this Ű���带 ���� Null Reference Exception �߻�
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}