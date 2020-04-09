using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{
    public PlayerController playerScript;
    public SimpleHealthBar healthBar;
    public GameObject menuPanel;
    public GameObject helpPanel;
    public GameObject gameOverPanel;
    AudioSource audioSource;
    public AudioListener audioListener;
    public bool playerIsDead;
    Score highScore;
    public Text scoreText;


    void Awake()
    {   playerIsDead = false;
        gameOverPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        menuPanel.SetActive(false);
        helpPanel.SetActive(false);
        highScore = playerScript.GetComponent<Score>();
    }
    public void Menu()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        helpPanel.SetActive(false);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }
    public void Help()
    {
        Time.timeScale = 0;
        helpPanel.SetActive(true);
    }
    public void SoundOffOn()
    {
        if(audioListener.enabled == true)
        {
            audioListener.enabled = false;
        }
        else
        {
            audioListener.enabled = true;
        }

    }

    public void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    

    void Update()
    {
        
        if(playerIsDead && gameOverPanel.activeInHierarchy==false)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
            scoreText.text = "HighScore:" + highScore.currentScore.ToString();
        }
        healthBar.UpdateBar(playerScript.currentHP, playerScript.maxHp);
    }
}
