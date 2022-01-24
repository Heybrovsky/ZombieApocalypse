using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class deathNote : MonoBehaviour
{
    public int enemiesKilled;
    public TMP_Text nrOfDeadEnemies;
    public string killedEnemiesTxt = "Killed enemies: ";
    


    void Update()
    {
        nrOfDeadEnemies.text = killedEnemiesTxt + enemiesKilled.ToString();

    }
}
