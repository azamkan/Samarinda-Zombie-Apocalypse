using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject exitPanel;        // Panel peringatan keluar
    public Button yesButton;            // Tombol YA
    public Button noButton;             // Tombol TIDAK

    private void Start()
    {
        exitPanel.SetActive(false);     // Sembunyikan panel di awal

        yesButton.onClick.AddListener(ExitGame);
        noButton.onClick.AddListener(ClosePanel);
    }

    public void SelectLevel(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void ClosePanel()
    {
        exitPanel.SetActive(false); // Sembunyikan panel
    }

    public void showpanelexit()
    {
        exitPanel.SetActive(true);
    }

}
