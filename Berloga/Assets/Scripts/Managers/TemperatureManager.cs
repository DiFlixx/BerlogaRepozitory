using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    public int maxTemperature = 70;
    public int currentTemperature;
    public int temperatureDecayRate = 1;
    [SerializeField]
    private HealthManager _healthManager;

    [SerializeField]
    private TemperatureUI _temperatureUI;

    void Start()
    {
        currentTemperature = maxTemperature;
        InvokeRepeating("DecayTemperature", 2f, 2f);
    }

    void DecayTemperature()
    {
        currentTemperature -= temperatureDecayRate;
        currentTemperature = Mathf.Clamp(currentTemperature, 0, maxTemperature);
        _temperatureUI.UpdateTemperatureUI();
        if (currentTemperature <= 0)
        {
            _healthManager.TakeDamage(1);
        }
    }

    public int GetTemperature()
    {
        return currentTemperature;
    }

}
