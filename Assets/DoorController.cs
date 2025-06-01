using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform destination;
    private GameObject player;
    private bool isPlayerInRange = false;
    public bool isDoorUnlocked;

    private GameObject ui;
    private PlayerInventory playerInventory;

    [Header("Pesan dari Inspector")]
    [TextArea]
    public string lockedMessage = "Pintu terkunci! Cari kunci.";
    [TextArea]
    public string hasKeyMessage = "Tekan 'F' untuk membuka pintu (kunci tersedia).";
    [TextArea]
    public string unlockedMessage = "Tekan 'F' untuk membuka pintu.";

    [Header("--- SFX confirm ---")]
    public bool suaraPintuAda;

    AudioManager audioManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();

        ui = GameObject.Find("UIManager");

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (isDoorUnlocked)
                {
                    TeleportPlayer();
                }
                else
                {
                    if (playerInventory != null && playerInventory.hasKey)
                    {
                        isDoorUnlocked = true;
                        playerInventory.UseKey();
                        TeleportPlayer();
                    }
                    else
                    {
                        ui.GetComponent<PlayerUIController>().SetTaskText(lockedMessage);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isDoorUnlocked)
            {
                ui.GetComponent<PlayerUIController>().SetTaskText(unlockedMessage);
            }
            else if (playerInventory.hasKey)
            {
                ui.GetComponent<PlayerUIController>().SetTaskText(hasKeyMessage);
            }
            else
            {
                ui.GetComponent<PlayerUIController>().SetTaskText(lockedMessage);
            }

            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            ui.GetComponent<PlayerUIController>().SetTaskText(""); // Kosongkan perintah
        }
    }

    private void TeleportPlayer()
    {
        if (suaraPintuAda)
        {
            audioManager.PlaySFX(audioManager.pintu);
        }
        player.transform.position = destination.position;
    }
}
