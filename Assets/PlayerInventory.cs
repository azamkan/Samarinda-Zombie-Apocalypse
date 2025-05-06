using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int foodCount = 0;
    public int medicineCount = 0;
    public bool hasKey = false;
    public bool hasFuel = false;

    public void AddFood()
    {
        foodCount++;
    }

    public void AddMedicine()
    {
        medicineCount++;
    }

    public void AddKey()
    {
        hasKey = true;
    }

    public void AddFuel()
    {
        hasFuel = true;
    }

    public void UseKey()
    {
        hasKey = false;
    }

    public void UseFuel()
    {
        hasFuel = false;
    }

    public void UseFood(PlayerHealth health)
    {
        if (foodCount > 0)
        {
            foodCount--;
            health.RestoreHP(20);
        }
    }

    public void UseMedicine(PlayerHealth health)
    {
        if (medicineCount > 0)
        {
            medicineCount--;
            health.CureInfection(30);
        }
    }
}
