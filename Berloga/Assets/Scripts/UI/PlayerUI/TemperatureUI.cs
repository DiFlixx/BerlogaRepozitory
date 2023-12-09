using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureUI : MonoBehaviour
{
    [SerializeField]
    private TemperatureManager temperatureManager;

    [SerializeField]
    private Image temperatureIcon;
    [SerializeField]
    private Sprite[] temperatureSprites;

    public void UpdateTemperatureUI()
    {
        int temperature = temperatureManager.GetTemperature();

        int temperatureType = Mathf.Clamp(temperature/10, 0, temperatureSprites.Length - 1);

        temperatureIcon.sprite = temperatureSprites[temperatureType];
    }

    void Start()
    {
        UpdateTemperatureUI();
    }
}
