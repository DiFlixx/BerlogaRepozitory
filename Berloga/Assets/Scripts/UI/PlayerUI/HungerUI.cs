using UnityEngine;
using UnityEngine.UI;

public class HungerUI : MonoBehaviour
{
    [SerializeField]
    private HungerSystem _hungerSystem;
    [SerializeField]
    private Image _hungerBar;

    void Update()
    {
        if (_hungerSystem != null && _hungerBar != null)
        {
            float normalizedHunger = _hungerSystem.currentHunger / _hungerSystem.maxHunger;
            _hungerBar.rectTransform.localScale = new Vector3(normalizedHunger, 1f, 1f);
            _hungerBar.rectTransform.anchorMin = new Vector2(0f, 0f);
            _hungerBar.rectTransform.pivot = new Vector2(0f, 0.5f);

        }
    }
}


