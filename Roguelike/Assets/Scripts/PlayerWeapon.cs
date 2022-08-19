using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    GameObject player;
    int temp;

    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    void FixedUpdate()
    {
        if (player.GetComponent<Player>().stop_weapon_moving == false)
        {
            RotateForwardMouse(); //Update에 넣으면 떨림 현상 발생
            MoveWeapon((int)temp);
        }
    }

    void RotateForwardMouse()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 45;
        temp = (int)angle;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void MoveWeapon(int angle) //마우스가 플레이어 위에 있으면 좋지 않은 현상 발생
    {
        float x, y;
        float temp;

        //0 ~ 179 -1 ~ -180
        if (angle < -180) //-190 = 170 190
            angle = 180 + (180 + angle);

        if (angle < -135)
            angle = 135 + (180 + angle);
        else
            angle -= 45;

        if (angle >= 0)
        {
            temp = Mathf.Abs(90 - angle); //0 -> 0.5 90 -> 0
            x = -0.5f + temp * (0.5f / 90);
        }
        else
        {
            temp = Mathf.Abs(-91 - angle);
            x = 0.5f - temp * (0.5f / 90);
        }

        if (angle <= 90 && angle >= -89)
        {
            if (angle >= 1)
                temp = angle;
            else
                temp = Mathf.Abs(angle);
            y = 0.5f - temp * (0.5f / 90);
        }
        else
        {
            if (angle <= -90)
                temp = angle + 180;
            else
                temp = 180 - angle;
            y = -0.5f + temp * (0.5f / 90);
        }

        transform.localPosition = new Vector2(x, y);
    }
}