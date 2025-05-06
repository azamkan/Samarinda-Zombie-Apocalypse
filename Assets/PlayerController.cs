using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject attackHitbox;

    private PlayerHealth playerHealth;
    private PlayerInventory playerInventory;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerInventory = GetComponent<PlayerInventory>();

        // Pastikan hitbox nonaktif saat mulai
        if (attackHitbox != null)
            attackHitbox.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackHitbox.SetActive(true);
            Invoke(nameof(DisableAttackHitbox), 0.3f); // ubah durasi sesuai animasi
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerInventory.UseFood(playerHealth);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerInventory.UseMedicine(playerHealth);
        }
    }

    private void DisableAttackHitbox()
    {
        if (attackHitbox != null)
            attackHitbox.SetActive(false);
    }
}
