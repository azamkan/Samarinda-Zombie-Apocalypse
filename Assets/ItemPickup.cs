using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    AudioManager audioManager;

    public enum ItemType
    {
        Key,
        Food,
        Medicine,
        Fuel
    }

    public ItemType itemType;

    private bool isPlayerInRange = false;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            audioManager.PlaySFX(audioManager.ambilbarang);
            PickupItem();
        }
    }

    private void PickupItem()
    {
        if (playerInventory != null)
        {
            switch (itemType)
            {
                case ItemType.Key:
                    playerInventory.AddKey();
                    break;
                case ItemType.Food:
                    playerInventory.AddFood();
                    break;
                case ItemType.Medicine:
                    playerInventory.AddMedicine();
                    break;
                case ItemType.Fuel:
                    playerInventory.AddFuel();
                    break;
            }

            Destroy(gameObject); // Hapus item dari scene
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            playerInventory = collision.GetComponent<PlayerInventory>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            playerInventory = null;
        }
    }
}
