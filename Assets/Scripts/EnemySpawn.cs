using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawn : MonoBehaviour
{
    public playerScript playerScript;
    public deathNote deathNoteVariables;
    public int enemyHealth = 100;
    public int enemyAttackDamage = 50;
    public float enemyMovementSpeed = 1;
    public Transform objectToAttack;
    public playerScript playerVariables;
    private bool gotHitFS = false;
    public bool coroutineRunning;
    public MeshRenderer[] renderers;


    void Start()
    {
        Color newColor = Random.ColorHSV(0f, 1f, 0.6f, 0.6f);
        ApplyMaterial(newColor, 0);
       
    }

    void ApplyMaterial(Color color, int targetMaterialIndex)
    {
        Material generatedMaterial = new Material(Shader.Find("Standard"));
        generatedMaterial.SetColor("_Color", color);
        for(int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = generatedMaterial;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
         
            Destroy(collision.gameObject);
            enemyHealth -= collision.gameObject.GetComponent<Bullet>().bulletDamage;
            if (enemyHealth <= 0)
            {
                enemyDeath();
            }
        }

        if (collision.gameObject.tag == "Player")
        {

            enemyAttack();
            Destroy(this.gameObject);
        }

    }



    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "fireStrike" && gotHitFS == false)
        {
            gotHitFS = true;

            enemyHealth -= collision.gameObject.GetComponent<fireStrike>().fireStrikeDMG;
            if (enemyHealth <= 0)
            {

                enemyDeath();
            }
        }

        if (collision.gameObject.tag == "iceBlast" && coroutineRunning == false)
        {
            StartCoroutine(WaitForStunToEnd(collision));
        }
        else if (collision.gameObject.tag == "iceBlast" && coroutineRunning == true)
        {
            collision.gameObject.GetComponent<iceBlast>().slowDuration = 5;
        }
    }

    void Update()
    {

        EnemyMovement();

    }

    void EnemyMovement()
    {
        transform.LookAt(objectToAttack);
        float step = enemyMovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, objectToAttack.position, step);
    }

    void enemyAttack()
    {
        playerScript.playerLogic.playerHealth -= enemyAttackDamage;
    }

    void enemyDeath() {
        deathNoteVariables.enemiesKilled++;
        this.gameObject.SetActive(false);
    }

    IEnumerator WaitForStunToEnd(Collider collision)
    {
        coroutineRunning = true;
            enemyMovementSpeed -= collision.gameObject.GetComponent<iceBlast>().iceBlastSlow / 100;
            yield return new WaitForSeconds(collision.gameObject.GetComponent<iceBlast>().slowDuration);
        coroutineRunning = false;
            enemyMovementSpeed /= enemyMovementSpeed;
        
    }

    
}
