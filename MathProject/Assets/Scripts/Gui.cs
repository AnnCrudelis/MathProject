using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    public VariableJoystick joystick;
    AudioSource audioSource;
    public AudioListener audioListener;
    public bool playerIsDead;
    Score highScore;
    public Text scoreText;


    void Awake()
    {
        joystick.gameObject.SetActive(true);
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
        joystick.gameObject.SetActive(false);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        joystick.gameObject.SetActive(true);
    }
    public void Help()
    {
        Time.timeScale = 0;
        helpPanel.SetActive(true);
        joystick.gameObject.SetActive(false);
    }
    public void SoundOffOn()
    {
        if(audioSource.enabled == true)
        {
            audioSource.enabled = false;
        }
        else
        {
            audioSource.enabled = true;
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
            joystick.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
            string path = Directory.GetCurrentDirectory();
            string save = @"\save.txt";
            string textFromFile = "";
            try
            {
                using (FileStream fstream = File.OpenRead($"{path}{save}"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.ReadAsync(array, 0, array.Length);

                    textFromFile = System.Text.Encoding.Default.GetString(array);
                }
                if (int.Parse(textFromFile) < highScore.currentScore)
                {
                    using (FileStream fstream = new FileStream($"{path}{save}", FileMode.OpenOrCreate))
                    {
                        byte[] array = System.Text.Encoding.Default.GetBytes(highScore.currentScore.ToString());
                        fstream.WriteAsync(array, 0, array.Length);
                        Debug.Log(highScore.currentScore.ToString());
                        scoreText.text = "HighScore:" + highScore.currentScore.ToString();
                    }
                }
                else
                {
                    scoreText.text = "HighScore:" + textFromFile.ToString();
                }
            }
            catch
            {
                using (FileStream fstream = new FileStream($"{path}{save}", FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(highScore.currentScore.ToString());
                    // асинхронная запись массива байтов в файл
                    fstream.WriteAsync(array, 0, array.Length);
                    Debug.Log("Текст записан в файл");
                    scoreText.text = "HighScore:" + highScore.currentScore.ToString();
                }
            }
        }
        healthBar.UpdateBar(playerScript.currentHP, playerScript.maxHp);
    }
}
