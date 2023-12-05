using UnityEngine;

public class Snow : MonoBehaviour
{
    public float waterRestoreAmount = 10f;
    public float cooldownTime = 5f;
    public Color highlightColor = Color.yellow;


    private Color originalColor;
    private Renderer renderer;


    [SerializeField]
    private HungerSystem _hungerSystem;
    private bool canActivate = true;
    private bool isMouse = false;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
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
        renderer.material.color = highlightColor;
        isMouse = true;
    }

    void OnMouseExit()
    {
        renderer.material.color = originalColor;
        isMouse = false;
    }
}
