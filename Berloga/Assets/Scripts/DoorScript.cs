using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject hint;
    public bool isPlayerNear = false;

    private void HideHintE()
    {
        hint.SetActive(false);
    }

    private void ShowHintE()
    {
        hint.SetActive(true);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
            ShowHintE();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
            HideHintE();
        }
    }

    public void GoToRoom(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            GoToRoom("Room");
        }
    }
}