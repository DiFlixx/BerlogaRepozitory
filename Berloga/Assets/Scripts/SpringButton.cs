using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickButton : MonoBehaviour
{
    private PlayerController controller;
    [SerializeField] private GameObject target;

    void Start()
    {
        controller = FindObjectOfType<PlayerController>();
    }

    public void Create()
    {
        Debug.Log(target.name + " " + controller.name);
        Instantiate(target.gameObject, controller.transform.parent, false).transform.position = controller.transform.position - new Vector3(0, 0.6f, 0);
    }
}
