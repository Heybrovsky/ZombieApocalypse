using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject difficultyMenu;
    public GameObject MainMenu;
    public PlayerLogic LogicValue;
    public EnemyLogic EnemyValue;

    private void Awake()
    {
        EnemyValue = new EnemyLogic();
        LogicValue = new PlayerLogic();
    }
    public void NewGame()
    {
        MainMenu.SetActive(!MainMenu.activeInHierarchy);
        difficultyMenu.SetActive(!difficultyMenu.activeInHierarchy);
    }

    public void EasyGame()
    {
        LogicValue.PlayerHealth = 250;
        EnemyValue.TimeToSpawn = 0.4f;
        Time.timeScale = 1;
        LogicValue.AliveTime = 0;
        SceneManager.LoadScene("Gameplay");
    }

    public void MediumGame()
    {
        LogicValue.PlayerHealth = 150;
        EnemyValue.TimeToSpawn = 0.2f;
        Time.timeScale = 1;
        LogicValue.AliveTime = 0;
        SceneManager.LoadScene("Gameplay");
    }

    public void HardGame()
    {
        LogicValue.PlayerHealth = 50;
        EnemyValue.TimeToSpawn = 0.1f;
        Time.timeScale = 1;
        LogicValue.AliveTime = 0;
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
