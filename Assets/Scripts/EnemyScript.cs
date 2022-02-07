using System.Collections;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    public EnemyLogic EnemyValue;
    public deathNote DeathNoteVariables;
    public Transform ObjectToAttack;
    public MeshRenderer[] Renderers;
    public PlayerScript Player;

    void Awake()
    {
        EnemyValue = new EnemyLogic();
    }
    void Start()
    {
        Color newColor = Random.ColorHSV(0f, 1f, 0.6f, 0.6f);
        ApplyMaterial(newColor);
       
    }

    void ApplyMaterial(Color color)
    {
        Material generatedMaterial = new Material(Shader.Find("Standard"));
        generatedMaterial.SetColor("_Color", color);
        for(int i = 0; i < Renderers.Length; i++)
        {
            Renderers[i].material = generatedMaterial;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.SetActive(false);
            EnemyValue.EnemyHealth -= Player.LogicValue.BulletDamage;
            if (EnemyValue.EnemyHealth <= 0)
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

        if (collision.gameObject.tag == "fireStrike" && EnemyValue.GotHitFS == false)
        {
            EnemyValue.GotHitFS = true;
            EnemyValue.EnemyHealth -= collision.gameObject.GetComponent<fireStrike>().fireStrikeDMG;
            if (EnemyValue.EnemyHealth <= 0)
            {

                enemyDeath();
            }
        }

        if (collision.gameObject.tag == "iceBlast" && EnemyValue.CoroutineRunning == false)
        {
            StartCoroutine(WaitForStunToEnd(collision));
        }
        else if (collision.gameObject.tag == "iceBlast" && EnemyValue.CoroutineRunning == true)
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
        transform.LookAt(ObjectToAttack);
        float step = EnemyValue.EnemyMovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, ObjectToAttack.position, step);
    }

    void enemyAttack()
    {
        Player.LogicValue.PlayerHealth -= EnemyValue.EnemyAttackDamage;
    }

    void enemyDeath() {
        DeathNoteVariables.enemiesKilled++;
        this.gameObject.SetActive(false);
    }

    IEnumerator WaitForStunToEnd(Collider collision)
    {
        EnemyValue.CoroutineRunning = true;
        EnemyValue.EnemyMovementSpeed -= collision.gameObject.GetComponent<iceBlast>().iceBlastSlow / 100;
        yield return new WaitForSeconds(collision.gameObject.GetComponent<iceBlast>().slowDuration);
        EnemyValue.CoroutineRunning = false;
        EnemyValue.EnemyMovementSpeed /= EnemyValue.EnemyMovementSpeed;
        
    }

    
}
