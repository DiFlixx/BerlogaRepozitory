using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    [SerializeField]
    private HungerSystem _hungerSystem;
    [SerializeField]
    private Image _waterBar;

    void Update()
    {
        if (_hungerSystem != null && _waterBar != null)
        {
            float normalizedWater = _hungerSystem.currentWater / _hungerSystem.maxWater;
            _waterBar.rectTransform.localScale = new Vector3(normalizedWater, 1f, 1f);
            _waterBar.rectTransform.anchorMin = new Vector2(0f, 0f);
            _waterBar.rectTransform.pivot = new Vector2(0f, 0.5f);

        }
    }
}


