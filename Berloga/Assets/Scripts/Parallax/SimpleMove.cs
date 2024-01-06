using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float speed = 3.0f;

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            
        }
        transform.Translate(new Vector2(
            Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0
            ));
    }
}
