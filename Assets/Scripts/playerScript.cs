using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    //widok 
    [SerializeField] private Camera mainCamera;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public GameObject DeathMenu;
    public Transform playerT;
    
    //logika
    public PlayerLogic playerLogic;

    void Start()
    {
        Color color1;
        ColorUtility.TryParseHtmlString("#3600FF", out color1);
        GetComponent<Renderer>().material.color = color1;
    }

     void Update()
     {
         playerLogic.UpdateAliveTime(Time.deltaTime);
        
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
        Plane p = new Plane(Vector3.up, playerT.position);
        if (p.Raycast(mouseRay, out float hitDist))
        {
            Vector3 hitPoint = mouseRay.GetPoint(hitDist);
            playerT.LookAt(hitPoint);
        }

    }

    void playerDeath()
    {
        if(playerLogic.playerHealth <= 0)
        {
            playerLogic.death = true;
            Time.timeScale = 0;
            DeathMenu.SetActive(true);
        }
    }

    public void returnToMenu() {
        SceneManager.LoadScene("Mainmenu");
    }

    void playerShooting()
    {
       GameObject projectile = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
       projectile.transform.parent = bulletSpawnPoint.transform;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddRelativeForce(bulletSpawnPoint.forward * playerLogic.bulletForce, ForceMode.Impulse);
    }

    public bool IsMouseButtonClicked()
    {
        return Input.GetButtonDown("Fire1");
    }

}
