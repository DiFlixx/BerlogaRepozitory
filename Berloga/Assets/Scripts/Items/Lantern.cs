using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : Item, ICanLight, ICanStopLight, ICanLightBrighter
{
    [SerializeField]
    private GameObject _light;
    [SerializeField]
    private GameObject _light2;

    public void Light()
    {
        _light.gameObject.SetActive(true);
        _light2.gameObject.SetActive(false);
    }

    public void StopLight()
    {
        _light2.gameObject.SetActive(false);
        _light.gameObject.SetActive(false);
    }

    public void LightBrighter()
    {
        _light.gameObject.SetActive(false);
        _light2.gameObject.SetActive(true);
    }
}
