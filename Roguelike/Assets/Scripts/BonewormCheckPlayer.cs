using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonewormCheckPlayer : MonoBehaviour
{
    public bool can_fire = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
            can_fire = true;
        else
            can_fire = false;
    }
}
