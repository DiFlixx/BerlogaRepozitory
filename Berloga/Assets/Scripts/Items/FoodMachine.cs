using UnityEngine;
using UnityEngine.Events;

public class FoodMachine : Item, ITurnOffable, ITurnOnable, ICanGiveFood
{
    [SerializeField]
    private float cooldownTime = 5f;

    [SerializeField]
    private GameObject _food;
    [SerializeField]
    private Sprite _turnedOff;
    [SerializeField]
    private Sprite _turnedOn;

    public UnityEvent OnFoodDropped;

    private bool _isOn;

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
            OnFoodDropped?.Invoke();
        }
    }
}

