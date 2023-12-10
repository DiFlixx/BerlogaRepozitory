using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreLastEtap : MonoBehaviour
{
public int clicks;
    public GameObject FireThing;

    private void OnMouseDown()
    {
        if(clicks == 7)
        {
            FireThing.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            clicks++;
        }
    }
}
