using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    class DragnDrop : MonoBehaviour
    {
        public float offsetX = 1f;
        public float offsetY = 1f;
        public Camera cam;
        public Vector2 MousePos;
        private void Update()
        {
            MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        private void OnMouseDrag()
        {
            gameObject.transform.position = MousePos-new Vector2(offsetX,offsetY);
        }
    }
}
