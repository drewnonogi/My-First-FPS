using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalGameOverScreen : MonoBehaviour
{
    [SerializeField] private Button tryagainButton;
    [SerializeField] private Button MainMenuButton;

    private void Awake()
    {
        tryagainButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(2);
        });
        MainMenuButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        });
    }
}
