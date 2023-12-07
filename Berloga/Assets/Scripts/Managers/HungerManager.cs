using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    public int maxHunger = 6;
    public int currentHunger;
    public int maxWater = 6;
    public int currentWater;

    [SerializeField]
    private int hungerDecayRate = 1;
    [SerializeField]
    private int waterDecayRate = 1;
    [SerializeField]
    private HungerUI _hungerUI;

    void Start()
    {
        currentHunger = maxHunger;
        currentWater = maxWater;
        InvokeRepeating("DecayHunger", 5f, 5f);
        InvokeRepeating("DecayWater", 5f, 5f);
    }

    void Update()
    {
        if (currentHunger <= 0 || currentWater <= 0)
        {

        }
    }

    void DecayHunger()
    {
        currentHunger -= hungerDecayRate;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        _hungerUI.UpdateHungerUI();
    }

    void DecayWater()
    {
        currentWater -= waterDecayRate;
        currentWater = Mathf.Clamp(currentWater, 0, maxWater);
    }

    public void Eat(int amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        _hungerUI.UpdateHungerUI();
    }

    public void Drink(int amount)
    {
        currentWater += amount;
        currentWater = Mathf.Clamp(currentWater, 0, maxWater);
    }

    public int GetHunger()
    {
        return currentHunger;
    }

    public int GetWater()
    {
        return currentWater;
    }
}

