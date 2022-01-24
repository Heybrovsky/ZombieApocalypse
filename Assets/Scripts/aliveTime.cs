using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class aliveTime : MonoBehaviour
{
    public TMP_Text lastedAlive;


    void Update()
    {
        lastedAlive.text = "You were alive for " + playerScript.aliveTime.ToString("0") +" seconds.";
    }
}
