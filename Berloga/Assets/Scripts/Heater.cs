using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : Item, ITurnOffable, ITurnOnable
{
    [SerializeField]
    private GameObject _heatArea;
    [SerializeField]
    private Sprite _turnOffImage;
    [SerializeField]
    private Sprite _turnOnImage;
    
    private bool _isOn;
    private Coroutine _coroutine;

    public void TurnOff()
    {
        _isOn = false;
        _heatArea.SetActive(false);
        _spriteRenderer.sprite = _turnOffImage;
    }

    public void TurnOn()
    {
        _isOn = true;
        _spriteRenderer.sprite = _turnOnImage;
        /*if (_coroutine == null)
            _coroutine = StartCoroutine(TurnOffHeat());*/
    }

    /*private IEnumerator TurnOffHeat()
    {
        yield return new WaitForSeconds(20f);
        TurnOff();
        _coroutine = null;
    }*/

    public void Heat()
    {
        if (_isOn) 
        {
            _heatArea.SetActive(true);
        }
    }
}
