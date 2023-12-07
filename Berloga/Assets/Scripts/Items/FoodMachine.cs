using UnityEngine;

public class FoodMachine : MonoBehaviour
{
    [SerializeField]
    private int foodRestoreAmount = 10;
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
        RestoreFood();

        StartCooldown();
    }

    void RestoreFood()
    {
        _hungerSystem.Eat(foodRestoreAmount);
        Debug.Log("Еда восстановлена: " + foodRestoreAmount);
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

