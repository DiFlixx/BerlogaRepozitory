using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    public float maxHunger = 100f;
    public float currentHunger;
    public float maxWater = 100f;
    public float currentWater;
    public float hungerDecayRate = 1f;
    public float waterDecayRate = 1f;

    void Start()
    {
        currentHunger = maxHunger;
        currentWater = maxWater;
        InvokeRepeating("DecayHunger", 1f, 1f);
        InvokeRepeating("DecayWater", 3f, 3f);
    }

    void Update()
    {
        if (currentHunger <= 0 || currentWater <= 0)
        {
            Debug.Log("Вы умерли");
        }
    }

    void DecayHunger()
    {
        currentHunger -= hungerDecayRate;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
    }

    void DecayWater()
    {
        currentWater -= waterDecayRate;
        currentWater = Mathf.Clamp(currentWater, 0, maxWater);
    }

    public void Eat(float amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
    }

    public void Drink(float amount)
    {
        currentWater += amount;
        currentWater = Mathf.Clamp(currentWater, 0, maxWater);
    }
}

