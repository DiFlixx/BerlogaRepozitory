using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CheckPointScript : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    
    public int index;

    void Awake()
    {
        player1 = GameObject.Find("MainCharacter").transform;
        player2 = GameObject.Find("MainCharacter2").transform;

        if (DataContainer.checkpointindex == index) 
        {
            player1.position = transform.position;
            player2.position = player1.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "MainCharacter" | other.gameObject.name == "MainCharacter2")
        {
            DataContainer.checkpointindex = index;
        }
    }
}
