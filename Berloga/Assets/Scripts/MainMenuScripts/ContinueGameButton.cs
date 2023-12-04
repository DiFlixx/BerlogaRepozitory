using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGameButton : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}