using UnityEngine;

public class PhoneInteraction : MonoBehaviour
{
    public GeneratorInteraction generator;
    public bool helpCalled = false;
    //public GameObject interactionUI;

    private GameObject player;
    private bool isPlayerInRange = false;

    private GameObject ui;

    AudioManager audioManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ui = GameObject.Find("UIManager");

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                    //cek apakah generator nyala
                    if (generator.isActive)
                    {
                        CallHelp();
                    }
                    else
                    {
                        Debug.Log("generator belum menyala.");
                        ui.GetComponent<PlayerUIController>().SetTaskText("generator belum menyala.");
                    }
                }
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
    private void CallHelp()
    {
        helpCalled = true;
        //interactionUI?.SetActive(false);
        Debug.Log("Help is on the way!");
        // Trigger final wave atau heli bisa dipanggil di sini
        FindObjectOfType<FinalWaveManager>()?.StartFinalWaveTimer();
        ui.GetComponent<PlayerUIController>().SetTaskText("Berhasil memanggil bantuan");
        audioManager.PlayHelicopterSound();
        FindObjectOfType<HelicopterController>()?.ArriveHelicopter();

    }
}






    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") && !helpCalled)
    //    {
    //        if (generator != null && generator.isActive)
    //        {
    //            //interactionUI?.SetActive(true);

    //            if (Input.GetKeyDown(KeyCode.E))
    //            {
    //                CallHelp();
    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("Generator is not active. Can't use the phone.");
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        //interactionUI?.SetActive(false);
    //    }
    //}

    //private void CallHelp()
    //{
    //    helpCalled = true;
    //    //interactionUI?.SetActive(false);
    //    Debug.Log("Help is on the way!");
    //    // Trigger final wave atau heli bisa dipanggil di sini
    //}
