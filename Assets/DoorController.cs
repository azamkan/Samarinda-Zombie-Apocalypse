using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform destination;
    private GameObject player;
    private bool isPlayerInRange = false;
    public bool isDoorUnlocked;

    // Misal player punya script PlayerInventory yang punya variabel hasKey
    private PlayerInventory playerInventory;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (isDoorUnlocked)
                {
                    // Pintu sudah terbuka, langsung teleport
                    TeleportPlayer();
                }
                else
                {
                    // Pintu belum terbuka, cek apakah player punya kunci
                    if (playerInventory != null && playerInventory.hasKey)
                    {
                        // Player punya kunci, buka pintu
                        isDoorUnlocked = true;
                        playerInventory.UseKey(); // Hapus kunci dari player
                        TeleportPlayer();
                    }
                    else
                    {
                        Debug.Log("Pintu terkunci! Kamu butuh kunci.");
                    }
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

    private void TeleportPlayer()
    {
        player.transform.position = destination.position;
    }
}
