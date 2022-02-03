using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public playerScript playerScript;
    public GameObject difficultyMenu;
    public GameObject MainMenu;
    public void NewGame()
    {
        MainMenu.SetActive(!MainMenu.activeInHierarchy);
        difficultyMenu.SetActive(!difficultyMenu.activeInHierarchy);
    }

    public void EasyGame()
    {
        playerScript.playerLogic.playerHealth = 250;
        EnemySpawner.timeToSpawn = 0.4f;
        Time.timeScale = 1;
        playerScript.playerLogic.aliveTime = 0;
        SceneManager.LoadScene("Gameplay");
    }

    public void MediumGame()
    {
        playerScript.playerLogic.playerHealth = 150;
        EnemySpawner.timeToSpawn = 0.2f;
        Time.timeScale = 1;
        playerScript.playerLogic.aliveTime = 0;
        SceneManager.LoadScene("Gameplay");
    }

    public void HardGame()
    {
        playerScript.playerLogic.playerHealth = 50;
        EnemySpawner.timeToSpawn = 0.1f;
        Time.timeScale = 1;
        playerScript.playerLogic.aliveTime = 0;
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
