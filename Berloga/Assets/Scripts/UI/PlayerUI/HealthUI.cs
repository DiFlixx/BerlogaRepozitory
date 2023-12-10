using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private HealthManager healthManager;

    [SerializeField]
    private Image[] hearts;

    [SerializeField]
    private Sprite fullHeartSprite;
    [SerializeField]
    private Sprite halfHeartSprite;
    [SerializeField]
    private Sprite emptyHeartSprite;

    public void UpdateHealthUI()
    {
        int health = healthManager.GetHealth();


        for (int i = 0; i < hearts.Length; i++)
        {
            int heartType = Mathf.Clamp(health - i * 2, 0, 2);

            switch (heartType)
            {
                case 0:
                    hearts[i].sprite = emptyHeartSprite;
                    break;
                case 1:
                    hearts[i].sprite = halfHeartSprite;
                    break;
                case 2:
                    hearts[i].sprite = fullHeartSprite;
                    break;
            }
        }
    }

    void Start()
    {
        UpdateHealthUI();
    }
}