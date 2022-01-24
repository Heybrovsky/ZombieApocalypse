using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public static float timeToSpawn = 1f;
    public float spawnRadius = 25;
    public playerScript playerVariable;




    void Start()
    {
        StartCoroutine(SpawnEnemy());
 
    }




    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (playerVariable.death == false)
            {
                Instantiate(Enemy, new Vector3(Random.insideUnitSphere.x * spawnRadius, 0, Random.insideUnitSphere.z * spawnRadius), Quaternion.identity);
                
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

}

