using TMPro;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public TMP_Text hpText;
    public TMP_Text infectionText;
    public TMP_Text foodText;
    public TMP_Text medText;
    public TMP_Text keyText;
    public TMP_Text fuelText;
    public TMP_Text taskText;

    private PlayerHealth playerHealth;
    private PlayerInventory playerInventory;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (playerHealth == null || playerInventory == null) return;

        hpText.text = $"HP: {playerHealth.currentHealth}/{playerHealth.maxHealth}";
        infectionText.text = $"Infeksi: {playerHealth.currentInfection}/{playerHealth.maxInfection}";
        foodText.text = $"Makanan: {playerInventory.foodCount}";
        medText.text = $"Obat: {playerInventory.medicineCount}";
        keyText.text = $"Kunci: {(playerInventory.hasKey ? "Ada" : "Tidak Ada")}";
        fuelText.text = $"Bensin: {(playerInventory.hasFuel ? "Ada" : "Tidak Ada")}";
    }

    public void SetTaskText(string message)
    {
        taskText.text = message;
    }
}
