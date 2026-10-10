using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
public GameObject container;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            container.SetActive(true);
            Time.timeScale = 0f; 
            // Pause the game
        }
    }

    public void ResumeGame()
    {
        container.SetActive(false);
        Time.timeScale = 1f; 
        // Resume the game
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("StartScene");
    }
    //brings you back to menu screen
}
