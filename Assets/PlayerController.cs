using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject attackHitbox;

    private PlayerHealth playerHealth;
    private PlayerInventory playerInventory;

    private Animator anim;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerInventory = GetComponent<PlayerInventory>();

        // Pastikan hitbox nonaktif saat mulai
        if (attackHitbox != null)
            attackHitbox.SetActive(false);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("attack",  true);
            attackHitbox.SetActive(true);
            Invoke(nameof(DisableAttackHitbox), 0.55f); // ubah durasi sesuai animasi
            //anim.SetBool("attack", false);
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
        anim.SetBool("attack", false);
    }
}
