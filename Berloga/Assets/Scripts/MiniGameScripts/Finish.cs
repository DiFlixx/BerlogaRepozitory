using System.Collections;
using UnityEngine;

namespace Assets
{
    public class Finish : MonoBehaviour
    {
        public AudioSource sound;

        private void Start()
        {
            sound = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if(gameObject.transform.position == Vector3.zero)
            {
                sound.Play();
                sound = null;
            }
        }
    }
}