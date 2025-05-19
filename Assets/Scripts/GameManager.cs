using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool gameStarted;
    public GameObject PlatformSpawner;
    public GameObject gamePlayUI;
    public GameObject menuUI;
    public Text highScoreText;
    public Text scoreText;
    AudioSource audioSource;
    public AudioClip[] gameMusic;

    int score = 0;
    int highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best Score: " + highScore.ToString();
    }


    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        gameStarted = true;
        PlatformSpawner.SetActive(true);
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        audioSource.clip = gameMusic[1];
        audioSource.Play();
        StartCoroutine("UpdateScore");
    }

    public void GameOver()
    {
        PlatformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            // print("Score: " + score);
            scoreText.text = score.ToString();
        }
    }

    public void IncrementScore()
    {
        score += 2;

        audioSource.PlayOneShot(gameMusic[2], 0.2f);
    }

    public int GetScore()
    {
        return score;
    }

    void SaveHighScore(){
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
