using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
       void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    //simple script to restart the game when player presses R
}
