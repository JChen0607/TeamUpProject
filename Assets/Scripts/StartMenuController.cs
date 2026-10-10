using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Tutorial");
    }

     public void OnLevelClick()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void OnControlsClick()
    {
        SceneManager.LoadScene("ControlScene");
    }
    //just controls the scenes
}
