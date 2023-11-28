using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : MonoBehaviour, ITurnOffable, ITurnOnable
{
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
}
