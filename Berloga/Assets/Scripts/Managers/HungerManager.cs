using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    public int maxHunger = 6;
    public int currentHunger;

    [SerializeField]
    private int hungerDecayRate = 1;
    [SerializeField]
    private HungerUI _hungerUI;

    void Start()
    {
        currentHunger = maxHunger;
        InvokeRepeating("DecayHunger", 5f, 5f);
    }

    void Update()
    {
        if (currentHunger <= 0)
        {

        }
    }

    void DecayHunger()
    {
        currentHunger -= hungerDecayRate;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        _hungerUI.UpdateHungerUI();
    }

    public void Eat(int amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        _hungerUI.UpdateHungerUI();
    }

    public int GetHunger()
    {
        return currentHunger;
    }
}

