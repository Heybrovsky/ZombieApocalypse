using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public Transform playerT;
    public static int playerHealth = 100;
    public bool death;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletForce = 5f;
    public GameObject DeathMenu;
    public static float aliveTime = 0f;


    void Start()
    {
      
        Color color1;

        ColorUtility.TryParseHtmlString("#3600FF", out color1);
        GetComponent<Renderer>().material.color = color1;
    }

     void Update()
    {
        aliveTime = aliveTime + Time.deltaTime;
        playerMovement();
        playerDeath();
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)
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
        if(playerHealth <= 0)
        {
            death = true;
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
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddRelativeForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
    }
}
