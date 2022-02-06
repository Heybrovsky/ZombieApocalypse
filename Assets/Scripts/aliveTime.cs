using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class aliveTime : MonoBehaviour
{
    public TMP_Text LastedAlive;
    public PlayerScript Player;
    
    void Update()
    {
        LastedAlive.text = "You were alive for " + Player.LogicValue.AliveTime.ToString("0") +" seconds.";
    }
}
