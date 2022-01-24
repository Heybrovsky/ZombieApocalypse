using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class iceBlast : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject iceBlastPrefab;
    public float iceBlastSlow = 50;
    public float iceBlastMS = 10f;
    public float coolDownTimer;
    public bool isCooldown;
    public float slowDuration = 5f;
    public TMP_Text IceBlastCDtxt;


    void Start() {

       
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && isCooldown == false)
        {
            isCooldown = true;
            IceBlastCDtxt.gameObject.SetActive(true);
            IceBlastCDtxt.text = coolDownTimer.ToString();
            GameObject ibProjectile = Instantiate(iceBlastPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody rb = ibProjectile.GetComponent<Rigidbody>();
            rb.AddRelativeForce(bulletSpawnPoint.forward * iceBlastMS, ForceMode.Impulse);
            StartCoroutine(Cooldown());
        }

    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolDownTimer);
        isCooldown = false;
        IceBlastCDtxt.gameObject.SetActive(false);
    }
}
