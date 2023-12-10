using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;

    void Start()
    {
        backgroundMusic.Play();
    }
}
