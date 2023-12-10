using TMPro;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject itemToSpawn;
    public Transform spawnPoint;
    public Sprite empty;

    private SpriteRenderer _spriteRanderer;
    private bool _isMouse = false;
    private bool _isEmpty = false;

    private void Start()
    {
        _spriteRanderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isEmpty && _isMouse)
        {
            SpawnItemAndDestroyBox();
        }
    }

    private void SpawnItemAndDestroyBox()
    {
        _isEmpty = true;
        Instantiate(itemToSpawn, spawnPoint.position, Quaternion.identity);
        _spriteRanderer.sprite = empty;
    }

    void OnMouseEnter()
    {
        _isMouse = true;
    }

    void OnMouseExit()
    {
        _isMouse = false;
    }
}

