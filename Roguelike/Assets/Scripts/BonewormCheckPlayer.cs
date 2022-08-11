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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
            can_fire = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
            can_fire = false;
    }
}
