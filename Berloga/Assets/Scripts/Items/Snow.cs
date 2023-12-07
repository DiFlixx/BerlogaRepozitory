using UnityEngine;

public class Snow : MonoBehaviour
{
    [SerializeField]
    private int waterRestoreAmount = 10;
    [SerializeField]
    private float cooldownTime = 5f;
    [SerializeField]
    private Color highlightColor = Color.yellow;


    private Color _originalColor;
    private Renderer _renderer;


    [SerializeField]
    private HungerSystem _hungerSystem;
    private bool canActivate = true;
    private bool isMouse = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivate && isMouse)
        {
            ActivateMachine();
        }
    }

    void ActivateMachine()
    {
        RestoreWater();

        StartCooldown();
    }

    void RestoreWater()
    {
        _hungerSystem.Drink(waterRestoreAmount);
        Debug.Log("Вода восстановлена: " + waterRestoreAmount);
    }

    void StartCooldown()
    {
        canActivate = false;
        Invoke("ResetActivation", cooldownTime);
    }

    void ResetActivation()
    {
        canActivate = true;
    }

    void OnMouseEnter()
    {
        _renderer.material.color = highlightColor;
        isMouse = true;
    }

    void OnMouseExit()
    {
        _renderer.material.color = _originalColor;
        isMouse = false;
    }
}
