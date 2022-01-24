using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EnemySpawn enemy;
    public int bulletDamage;
    public int healthCur;
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

  /*void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            healthCur = bulletDamage - other.gameObject.GetComponent<EnemySpawn>.enemyHealth;
            if (healthCur <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }


    void Update()
    {
        

    }

    void bulletAttack()
    {
        Debug.Log("ShouldBeDmgd");
        enemy.enemyHealth = enemy.enemyHealth - bulletDamage;
    }*/
}
