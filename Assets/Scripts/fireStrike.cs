using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fireStrike : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject fireStrikePrefab;
    public int fireStrikeDMG = 60;
    public int fireStrikeMS = 15;
    public float coolDownTimer;
    public bool isCooldown;
    public TMP_Text fireStrikeCDtxt;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isCooldown == false)
        {
            isCooldown = true;
            fireStrikeCDtxt.gameObject.SetActive(true);
            fireStrikeCDtxt.text = coolDownTimer.ToString();
            GameObject fsProjectile = Instantiate(fireStrikePrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody rb = fsProjectile.GetComponent<Rigidbody>();
            rb.AddRelativeForce(bulletSpawnPoint.forward * fireStrikeMS, ForceMode.Impulse);
            StartCoroutine(Cooldown());
        }

    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolDownTimer);
        isCooldown = false;
        fireStrikeCDtxt.gameObject.SetActive(false);
    }
}
