using System.Collections;
using UnityEditor.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        TransferDoor("CampfireMiniGame");
    }
    private static void TransferDoor(string scene) 
    {
        SceneManager.LoadScene(scene);
    }
}
