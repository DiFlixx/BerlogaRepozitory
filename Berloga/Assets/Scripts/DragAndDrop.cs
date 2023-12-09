using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    private void OnMouseDrag()
    {
        transform.position = GetMousePosition();
    }

    private Vector2 GetMousePosition()
    {
        if (Camera.main != null)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            return mousePosition;
        }

        return default;
    }
}