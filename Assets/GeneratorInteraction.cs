using UnityEngine;

public class GeneratorInteraction : MonoBehaviour
{
    public bool isActive = false;
    //public GameObject interactionUI;
    private PlayerInventory inventory;

    private GameObject player;
    private PlayerInventory playerInventory;
    private bool isPlayerInRange = false;

    private GameObject ui;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ui = GameObject.Find("UIManager");
        playerInventory = player.GetComponent<PlayerInventory>();
    }
    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //cek apakah generator nyala
                if (playerInventory != null && playerInventory.hasFuel)
                {
                    playerInventory.UseFuel();
                    ActivateGenerator();
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
    private void ActivateGenerator()
    {
        isActive = true;
        //interactionUI?.SetActive(false);
        Debug.Log("Generator is now active!");
        ui.GetComponent<PlayerUIController>().SetTaskText("generator menyala, segera panggil bantuan.");
        // Bisa ditambahkan animasi, suara, dll
    }






    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") && !isActive)
    //    {
    //        //interactionUI?.SetActive(true);

    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            //PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
    //            if (inventory != null && inventory.hasFuel)
    //            {
    //                inventory.UseFuel();
    //                ActivateGenerator();
    //            }
    //            else
    //            {
    //                Debug.Log("You need fuel to activate the generator!");
    //            }
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

    //private void ActivateGenerator()
    //{
    //    isActive = true;
    //    //interactionUI?.SetActive(false);
    //    Debug.Log("Generator is now active!");
    //    // Bisa ditambahkan animasi, suara, dll
    //}
}
