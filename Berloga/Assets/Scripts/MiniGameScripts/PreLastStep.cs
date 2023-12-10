using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreLastEtap : MonoBehaviour
{
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public int clicks;
    public GameObject FireThing;
    public AudioSource sound;

    private void OnMouseDown()
    {
        if (clicks == 7)
        {
            FireThing.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            clicks++;
        }

        sound.Play();
    }
}
