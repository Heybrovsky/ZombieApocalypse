using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    public PlayerScript Player;
    public EnemyScript EnemyAccess;
    public ObjectPooler ObjectPoolerAccess;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
 
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (Player.LogicValue.Death == false)
            {
                //Instantiate(Enemy, new Vector3(Random.insideUnitSphere.x * EnemyAccess.EnemyValue.spawnRadius, 0, Random.insideUnitSphere.z * EnemyAccess.EnemyValue.spawnRadius), Quaternion.identity);
                ObjectPoolerAccess.SpawnFromPool("Enemy",
                    new Vector3(Random.insideUnitSphere.x * EnemyAccess.EnemyValue.spawnRadius, 0,
                        Random.insideUnitSphere.z * EnemyAccess.EnemyValue.spawnRadius), Quaternion.identity);
            }
            yield return new WaitForSeconds(EnemyAccess.EnemyValue.TimeToSpawn);
        }
    }

}

