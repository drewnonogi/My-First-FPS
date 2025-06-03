using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private float gameTimer = 0f;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private PlayerController playerController;
    private bool gameOver = false;
    [SerializeField] GameObject targets;
    private void Start()
    {

    }

    private void Update()
    {
        CheckWinCondition();
        UpdateTimer();
    }

    public void CheckWinCondition()
    {
        if (targets.transform.childCount == 0)
        {
            UpdateGameOverScreen();
            gameOver = true;
            Invoke("GameOverScreenShow", 2f);
        }

    }
    private void PauseGame()
    {
        playerController.UnlockCursor();
        Time.timeScale = 0f;
    }
    private void UpdateTimer()
    {
        if (gameOver == false)
        {
            gameTimer += Time.deltaTime;

        }
    }
    private void UpdateGameOverScreen()
    {
        timeText.text = $"All targets destroyed in: {gameTimer.ToString("#.###")}";
    }
    //private void StopTimer()
    //{
    //    endGameTimer = gameTimer;
    //}
    private void GameOverScreenShow()
    {
        gameOverScreen.SetActive(true);
        PauseGame();
    }
}
