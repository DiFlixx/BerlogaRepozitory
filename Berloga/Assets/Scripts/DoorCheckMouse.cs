using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCheckMouse : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (
        gameObject.transform.position.x - player.position.x <= 1 && 
        gameObject.transform.position.y - player.position.y <= 1 || 
        gameObject.transform.position.x + player.position.x <= 1 &&
        gameObject.transform.position.y + player.position.y <= 1
            )
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GoToRoom("Room");
                }
            }
    }

    public void GoToRoom(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}