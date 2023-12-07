using UnityEngine;
using UnityEngine.UI;

public class HungerUI : MonoBehaviour
{
    [SerializeField]
    private HungerSystem hungerManager;

    [SerializeField]
    private Image[] hungerIcons;

    [SerializeField]
    private Sprite fullHungerSprite;
    [SerializeField]
    private Sprite halfHungerSprite;
    [SerializeField]
    private Sprite emptyHungerSprite;

    public void UpdateHungerUI()
    {
        int hunger = hungerManager.GetHunger();

        for (int i = 0; i < hungerIcons.Length; i++)
        {
            int hungerType = Mathf.Clamp(hunger - i * 2, 0, 2);

            switch (hungerType)
            {
                case 0:
                    hungerIcons[i].sprite = emptyHungerSprite;
                    break;
                case 1:
                    hungerIcons[i].sprite = halfHungerSprite;
                    break;
                case 2:
                    hungerIcons[i].sprite = fullHungerSprite;
                    break;
            }
        }
    }

    void Start()
    {
        UpdateHungerUI();
    }
}