using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] TextMeshProUGUI hiScore;

    void Start()
    {
        hiScore.text = PlayerPrefs.GetFloat("hiScore", 0f).ToString();
    }

    public void GoToMain()
    {
        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void GoToCredits()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
