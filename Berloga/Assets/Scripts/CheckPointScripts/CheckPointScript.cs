using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public Transform player;
    public int index;

    void Awake()
    {
        player = GameObject.Find("MainCharacter").transform;

        if (DataContainer.checkpointindex == index) 
        {
            player.position = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "MainCharacter")
        {
            DataContainer.checkpointindex = index;
        }
    }
}
