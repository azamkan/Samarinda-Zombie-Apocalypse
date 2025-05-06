using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelScript : MonoBehaviour
{
    public void SelectLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
