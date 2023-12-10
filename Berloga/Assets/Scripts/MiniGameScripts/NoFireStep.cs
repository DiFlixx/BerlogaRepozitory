using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFireStep : MonoBehaviour
{
    public GameObject plank;
    public GameObject stick;
    public GameObject NoFire;
    public bool IsTouchingStick = false;
    public bool IsTouchingPlank = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stick2"))
        {
            IsTouchingStick = true;
        }
        if (collision.gameObject.CompareTag("plank"))
        {
            IsTouchingPlank = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stick2"))
        {
            IsTouchingStick = false;
        }
        if (collision.gameObject.CompareTag("plank"))
        {
            IsTouchingPlank = false;
        }
    }

    private void Update()
    {
        if(IsTouchingPlank && IsTouchingStick)
        {
            NoFire.transform.position = new Vector2(0,0);
            Destroy(plank);
            Destroy(stick);
            Destroy(gameObject);
        }
    }
}