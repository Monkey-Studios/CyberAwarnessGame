using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   public void RestartGame()
    {
        SceneManager.LoadScene("TrueOrFalseQuiz");
        GameLogicManager.scoreTotal = 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void CloseGame()
    {
        Debug.Log("Game has closed");
        Application.Quit();
    }  
    public void CardGame()
    {
        SceneController.cardScore = 0;
        SceneManager.LoadScene("MemoryCardSnapGame");
    }
    public void WackAVirus()
    {
        SceneManager.LoadScene("WackAVirus");
    }
    public void BossQuiz()
    {
        BossQuizGameLogic.bossCurrentHP = 100;
        BossQuizGameLogic.currentHP = 100;
        SceneManager.LoadScene("BossQuiz");
    }
    public void LoadWebPage()
    {
        Application.OpenURL("file:///C:/Users/georg/Desktop/CyberGame/CyberAwarnessProject/Assets/External%20Links/Web%20pages/information.html");
    }
}
