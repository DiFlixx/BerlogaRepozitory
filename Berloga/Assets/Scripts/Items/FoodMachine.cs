using UnityEngine;

public class FoodMachine : Item, ITurnOffable, ITurnOnable, ICanGiveFood
{
    [SerializeField]
    private float cooldownTime = 5f;

    [SerializeField]
    private CodePanel _codePanel;
    [SerializeField]
    private Color highlightColor = Color.yellow;
    [SerializeField]
    private GameObject _food;
    [SerializeField]
    private Sprite _turnedOff;
    [SerializeField]
    private Sprite _turnedOn;

    private bool _isOn;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivate && isMouse)
        {
            ActivatePanel();
        }
    }

    private void ActivatePanel()
    {
        _codePanel.gameObject.SetActive(true);
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

    void StartCooldown()
    {
        canActivate = false;
        Invoke("ResetActivation", cooldownTime);
    }

    void ResetActivation()
    {
        canActivate = true;
    }

    public void TurnOff()
    {
        _spriteRenderer.sprite = _turnedOff;
        _isOn = false;
    }

    public void TurnOn()
    {
        _spriteRenderer.sprite = _turnedOn;
        _isOn = true;
    }

    public void GiveFood()
    {
        if (_isOn)
        {
            Instantiate(_food, transform).transform.position = transform.position;
        }
    }
}

