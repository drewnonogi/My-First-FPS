using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenMenu : MonoBehaviour
{
    [SerializeField] private Button tryagainButton;
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        tryagainButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        });
        continueButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(2);
        });
    }
}
