using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    public GameObject helicopterObject;
    public bool playerRescued = false;
    private bool playerInZone = false;

    private void Start()
    {
        helicopterObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F))
        {
            playerRescued = true;
            RescuePlayer(); // Panggil fungsi untuk menyelamatkan
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }

    public void ArriveHelicopter()
    {
        helicopterObject.SetActive(true);
        Debug.Log("Helicopter has arrived!");
    }

    public bool IsPlayerRescued()
    {
        return playerRescued;
    }

    private void RescuePlayer()
    {
        Debug.Log("Player rescued! Final wave stopped.");
        FindObjectOfType<FinalWaveManager>()?.WinGame();
    }
}







//using UnityEngine;

//public class HelicopterController : MonoBehaviour
//{
//    public GameObject helicopterObject;
//    public bool playerRescued = false;

//    private void Start()
//    {
//        helicopterObject.SetActive(false);
//    }

//    public void ArriveHelicopter()
//    {
//        helicopterObject.SetActive(true);
//        Debug.Log("Helicopter has arrived!");
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            playerRescued = true;
//            FindObjectOfType<FinalWaveManager>()?.WinGame();
//        }
//    }

//    public bool IsPlayerRescued()
//    {
//        return playerRescued;
//    }
//}






//using UnityEngine;

//public class HelicopterController : MonoBehaviour
//{
//    public float arrivalTime = 10f; // waktu sebelum helikopter muncul
//    public GameObject helicopterObject; // referensi GameObject heli
//    public FinalWaveManager waveManager;

//    private bool playerRescued = false;

//    private void Start()
//    {
//        helicopterObject.SetActive(false);
//        Invoke(nameof(ArriveHelicopter), arrivalTime);
//    }

//    private void ArriveHelicopter()
//    {
//        helicopterObject.SetActive(true);
//        Debug.Log("Helicopter has arrived!");
//        waveManager.StartFinalWaveTimer();
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            playerRescued = true;
//            waveManager.WinGame();
//        }
//    }

//    public bool IsPlayerRescued()
//    {
//        return playerRescued;
//    }
//}
