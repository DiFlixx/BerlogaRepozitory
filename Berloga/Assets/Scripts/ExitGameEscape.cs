using UnityEngine;

public class ExitGameEscape : ExitGameButton
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}