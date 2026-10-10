using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
public void OnLevel1Click()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnLevel2Click()
    {
        SceneManager.LoadScene("Level2");
    }
    public void OnLevel3Click()
    {
        SceneManager.LoadScene("Level3");
    }
    public void OnLevel4Click()
    {
        SceneManager.LoadScene("Level4");
    }
    public void OnLevel5Click()
    {
        SceneManager.LoadScene("Level5");
    }
    public void OnStartSceneClick()
    {
        SceneManager.LoadScene("StartScene");
    }
    //loads level when player clicks on the corresponding button 
}
