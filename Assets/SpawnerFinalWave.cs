using System.Collections;
using UnityEngine;

public class SpawnerFinalWave : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int zombiesPerWave = 5;
    public float spawnInterval = 10f;

    [Header("Random Speed Range")]
    public float minSpeed = 5.5f;
    public float maxSpeed = 8.5f;

    private bool spawningActive = false;

    public void StartSpawning()
    {
        if (!spawningActive)
        {
            spawningActive = true;
            StartCoroutine(SpawnZombies());
        }
    }

    private IEnumerator SpawnZombies()
    {
        while (spawningActive)
        {
            for (int i = 0; i < zombiesPerWave; i++)
            {
                GameObject zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity);

                // Set kecepatan acak
                EnemyAI enemyAI = zombie.GetComponent<EnemyAI>();
                if (enemyAI != null)
                {
                    enemyAI.moveSpeed = Random.Range(minSpeed, maxSpeed);
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StopSpawning()
    {
        spawningActive = false;
        StopAllCoroutines();
    }
}
