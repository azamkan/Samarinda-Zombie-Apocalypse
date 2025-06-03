using TMPro;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public TMP_Text foodText;
    public TMP_Text medText;
    public TMP_Text keyText;
    public TMP_Text fuelText;
    public TMP_Text taskText;
    public TMP_Text finalwaves;

    private PlayerHealth playerHealth;
    private PlayerInventory playerInventory;

    private bool hasMoved = false;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (playerHealth == null || playerInventory == null) return;

        // Deteksi pergerakan awal
        if (!hasMoved && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            hasMoved = true;
        }

        // Ubah UI berdasarkan apakah player sudah pernah bergerak
        if (!hasMoved)
        {
            foodText.text = $"{playerInventory.foodCount} X, tekan 1 untuk menggunakan";
            medText.text = $"{playerInventory.medicineCount} X, tekan 2 untuk menggunakan";
        }
        else
        {
            foodText.text = $"{playerInventory.foodCount} X";
            medText.text = $"{playerInventory.medicineCount} X";
        }

        keyText.text = $"{(playerInventory.hasKey ? "1" : "0")}";
        fuelText.text = $"{(playerInventory.hasFuel ? "1" : "0")}";
    }

    public void SetTaskText(string message)
    {
        taskText.text = message;
    }
    public void setFInalWaves(string message)
    {
        finalwaves.text = message;
    }
}
