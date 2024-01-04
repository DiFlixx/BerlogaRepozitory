using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadAfterDeath : MonoBehaviour
{
    private void MoveToCheckPoint(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
