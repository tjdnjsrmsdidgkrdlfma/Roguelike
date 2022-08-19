using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mouse;
    }
}
