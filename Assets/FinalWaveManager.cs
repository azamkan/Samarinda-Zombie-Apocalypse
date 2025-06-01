using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalWaveManager : MonoBehaviour
{
    public float finalWaveDuration = 60f;
    public SpawnerFinalWave[] spawners;
    public HelicopterController helicopterController;

    private bool waveStarted = false;
    private bool gameEnded = false;
    private Coroutine countdownCoroutine;

    private GameObject ui;

    private void Awake()
    {
        ui = GameObject.Find("UIManager");
    }

    public void StartFinalWaveTimer()
    {
        if (!waveStarted)
        {
            waveStarted = true;

            helicopterController.ArriveHelicopter();

            foreach (var spawner in spawners)
            {
                spawner.StartSpawning();
            }

            countdownCoroutine = StartCoroutine(FinalWaveCountdown());
        }
    }

    private IEnumerator FinalWaveCountdown()
    {
        float timer = finalWaveDuration;
        int lastLoggedSecond = Mathf.CeilToInt(timer);

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            int currentSecond = Mathf.CeilToInt(timer);
            if (currentSecond != lastLoggedSecond)
            {
                lastLoggedSecond = currentSecond;
                Debug.Log("Final wave ends in: " + currentSecond + " seconds");
                ui.GetComponent<PlayerUIController>().setFInalWaves("Segera Menuju Taman dalam: " + currentSecond + " detik");
            }

            yield return null;

            if (helicopterController.IsPlayerRescued())
            {
                yield break;
            }
        }

        if (!gameEnded)
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;

        // Stop all spawners
        foreach (var spawner in spawners)
        {
            spawner.StopSpawning();
        }

        // Destroy all existing zombies
        var allZombies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var zombie in allZombies)
        {
            Destroy(zombie);
        }

        // Stop timer if still running
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        Debug.Log("You Win! Player has been rescued.");
        // Tambahkan scene win atau UI di sini jika perlu
        SceneManager.LoadScene("win");
    }

    public void LoseGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        Debug.Log("You Lose! Waktu habis dan kamu tidak sampai ke helikopter.");
        // Tambahkan logic kalah di sini
    }
}








//using System.Collections;
//using UnityEngine;

//public class FinalWaveManager : MonoBehaviour
//{
//    public float finalWaveDuration = 60f;
//    public HelicopterController helicopterController;
//    public SpawnerFinalWave[] spawners;

//    private bool waveStarted = false;
//    private bool gameEnded = false;

//    public void StartFinalWaveTimer()
//    {
//        if (!waveStarted)
//        {
//            waveStarted = true;

//            // Munculkan helikopter saat bantuan dipanggil
//            helicopterController.ArriveHelicopter();

//            foreach (var spawner in spawners)
//            {
//                spawner.StartSpawning();
//            }

//            StartCoroutine(FinalWaveCountdown());
//        }
//    }


//    private IEnumerator FinalWaveCountdown()
//    {
//        float timer = finalWaveDuration;
//        int lastLoggedSecond = Mathf.CeilToInt(timer);

//        while (timer > 0)
//        {
//            timer -= Time.deltaTime;

//            int currentSecond = Mathf.CeilToInt(timer);
//            if (currentSecond != lastLoggedSecond)
//            {
//                lastLoggedSecond = currentSecond;
//                Debug.Log("Final wave ends in: " + currentSecond + " seconds");
//            }

//            yield return null;

//            if (helicopterController.IsPlayerRescued())
//            {
//                yield break;
//            }
//        }

//        if (!gameEnded)
//        {
//            LoseGame();
//        }
//    }


//    public void WinGame()
//    {
//        if (!gameEnded)
//        {
//            gameEnded = true;
//            Debug.Log("Player rescued! You win!");
//            // Bisa tambahkan transition ke scene lain
//            // SceneManager.LoadScene("VictoryScene");
//        }
//    }

//    public void LoseGame()
//    {
//        if (!gameEnded)
//        {
//            gameEnded = true;
//            Debug.Log("Time's up! You lose!");
//            // SceneManager.LoadScene("GameOverScene");
//        }
//    }
//}
