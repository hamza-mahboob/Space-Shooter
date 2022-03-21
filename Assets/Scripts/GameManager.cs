using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject pauseButton;
    public GameObject settingsButton;

    public AudioSource sound;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bestTimeText;

    float lives, time, bestTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //set lives and time text
        livesText.text = "Lives: " + lives.ToString();
        timeText.text = "Time: " + ((int)time).ToString();
        bestTimeText.text = "Best Time: " + bestTime.ToString();
    }

    public void SetBestTime(float time)
    {
        bestTime = time;
    }

    public void ReduceLife()
    {
        lives--;
        if (lives < 0)
        {
            lives = 0;
            //game over
            Debug.Log("Game Over");
        }
    }


    //UI
    public void PlayButton()
    {
        //menus disabled off when play is pressed
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);

        //buttons
        pauseButton.SetActive(true);
        settingsButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void SettingsButton()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void SoundOnButton()
    {
        sound.Play();
    }

    public void SoundOffButton()
    {
        sound.Stop();
    }
}
