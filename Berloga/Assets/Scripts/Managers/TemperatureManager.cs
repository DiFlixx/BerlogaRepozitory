using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    public int maxTemperature = 70;
    public int currentTemperature;
    public int temperatureDecayRate = 1;

    [SerializeField]
    private TemperatureUI _temperatureUI;

    void Start()
    {
        currentTemperature = maxTemperature;
        InvokeRepeating("DecayTemperature", 1f, 1f);
    }

    void Update()
    {
        if (currentTemperature <= 0)
        {
            // Обработка ситуации, когда температура достигла нуля
        }
    }

    void DecayTemperature()
    {
        currentTemperature -= temperatureDecayRate;
        currentTemperature = Mathf.Clamp(currentTemperature, 0, maxTemperature);
        _temperatureUI.UpdateTemperatureUI();
    }

    public int GetTemperature()
    {
        return currentTemperature;
    }

}
