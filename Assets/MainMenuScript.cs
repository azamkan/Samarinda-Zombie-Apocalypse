using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void SelectLevel(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
