using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //widok 
    [SerializeField] private Camera mainCamera;
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public GameObject DeathMenu;
    public Transform PlayerT;

    public ObjectPooler ObjectPoolerAccess;
    //logika 
    public PlayerLogic LogicValue;

    private void Awake()
    {
        LogicValue = new PlayerLogic();
    }

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

     void Update()
     {
         LogicValue.UpdateAliveTime(Time.deltaTime);
        
        playerMovement();
        playerDeath();
        if (IsMouseButtonClicked() && Time.timeScale != 0)
        {
            playerShooting();
        }
    }

    void playerMovement()
    {
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane p = new Plane(Vector3.up, PlayerT.position);
        if (p.Raycast(mouseRay, out float hitDist))
        {
            Vector3 hitPoint = mouseRay.GetPoint(hitDist);
            PlayerT.LookAt(hitPoint);
        }

    }

    void playerDeath()
    {
        if(LogicValue.PlayerHealth <= 0)
        {
            LogicValue.Death = true;
            Time.timeScale = 0;
            DeathMenu.SetActive(true);
        }
    }

    public void returnToMenu() {
        SceneManager.LoadScene("Mainmenu");
    }

    void playerShooting()
    {
  
        GameObject projectile = ObjectPoolerAccess.SpawnFromPool("Bullet", BulletSpawnPoint.position, Quaternion.identity);
       Rigidbody rb = projectile.GetComponent<Rigidbody>();
       rb.velocity = Vector3.zero;
        rb.AddRelativeForce(BulletSpawnPoint.forward * LogicValue.BulletForce, ForceMode.Impulse);
    }

    public bool IsMouseButtonClicked()
    {
        return Input.GetButtonDown("Fire1");
    }

}
