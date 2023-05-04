using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    

    private float gameTime = 90f; // total game time in seconds
    public float currentTime = 0f; // current time in seconds
     ////////////////////////////////////////////////////////////////////////////////////////////////// TEMPORARY ///////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public float timer = 0.0f; // timer for spawning clones 
    public float interval = 1.0f;
    public bool isPaused = true; // flag indicating if the game is paused
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public GameObject playPanel;
    public GameObject inGame;
    public GameObject pauseUI; // UI Panel 2
    public GameObject helpUI; // UI Panel 3

    public GameObject gameOverUI;

    public GameObject circle;
    public Sprite[] images;
    private SpriteRenderer spriteRendererCircle;
    public TMP_Text timeLeftText;

    public Slider timerSlider;

    public TMP_Text scoreFinal;

    private RandomPrefabGenerator randomPrefabGenerator;

    // Start is called before the first frame update
    void Start()
    {   
        // set initial UI state
        playPanel.SetActive(true);
        inGame.SetActive(false);
        pauseUI.SetActive(false);
        helpUI.SetActive(false);
        gameOverUI.SetActive(false);
        randomPrefabGenerator = GameObject.FindObjectOfType<RandomPrefabGenerator>();
        circle = GameObject.Find("Circle");
        spriteRendererCircle = circle.GetComponent<SpriteRenderer>();
        circle.SetActive(false);
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;

    }

    // Update is called once per frame
    void Update()
    {   
        if (!isPaused)
        {   
            // update current time
            currentTime += Time.deltaTime;
            timerSlider.value = gameTime - currentTime;
            // check if game is over
            if (currentTime >= gameTime)
            {
                GameOver();
            }
            
        }
        // update time left text
        UpdateTimeLeftText();
    }

    // function to start the game
    public void StartGame()
    {
        isPaused = false;
        playPanel.SetActive(false);
        inGame.SetActive(true);
        circle.SetActive(true);
        pauseUI.SetActive(false);
        helpUI.SetActive(false);
        gameOverUI.SetActive(false);
        randomPrefabGenerator.isGamePaused = false;
        spriteRendererCircle.sprite = images[0];
        
    }

    // function to pause the game
    public void PauseGame()
    {
        isPaused = true;
        pauseUI.SetActive(true);
    }

    // function to resume the game
    public void ResumeGame()
    {
        isPaused = false;
        pauseUI.SetActive(false);
        helpUI.SetActive(false);
    }

    // function to start help UI
    public void StartHelp()
    {
        isPaused = true;
        helpUI.SetActive(true);
    }
    // function to restart the game
    public void RestartGame()
    {
        isPaused = true;
        currentTime = 0f;
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject clone in clones) {
                Destroy(clone);
        }
        randomPrefabGenerator.score = 0;
        randomPrefabGenerator.scoreT.text = "0";
        randomPrefabGenerator.isGamePaused = false;
        isPaused = false;
        spriteRendererCircle.sprite = images[0];
        circle.SetActive(true);
    }
    // function to exit the game
    public void ExitGame()
    {
        isPaused = true;
        currentTime = 0f;
        randomPrefabGenerator.score = 0;
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject clone in clones) {
            Destroy(clone);
        }        
        playPanel.SetActive(true);
        inGame.SetActive(false);
        pauseUI.SetActive(false);
        helpUI.SetActive(false);
        gameOverUI.SetActive(false);
        circle.SetActive(false);
        spriteRendererCircle.sprite = images[0];
    }

    // function to format the time-left into text
    private void UpdateTimeLeftText()
    {
        float timeLeft = Mathf.Max(gameTime - currentTime, 0f); // calculate time left, ensuring it's not negative
        int minutes = Mathf.FloorToInt(timeLeft / 60f); // calculate minutes
        int seconds = Mathf.FloorToInt(timeLeft % 60f); // calculate seconds
        timeLeftText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); // format time as "00:00" and set textmeLeftText.text = seconds.ToString("00:00"); // format time as two digits with leading zeros and set text
    }

    public void GameOver() 
    {
        gameOverUI.SetActive(true);
        isPaused = true;
        pauseUI.SetActive(true);
        int score = randomPrefabGenerator.score;
        scoreFinal.text = ("Your Score : " + score);
        gameOverUI.SetActive(true);
        circle.SetActive(false);
    }
}
