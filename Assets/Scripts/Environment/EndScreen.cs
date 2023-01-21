using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreEndText;
    public TextMeshProUGUI hiScoreText;
    public float scoreFinal;


    void Start()
    {
        if (PlayerMove.Instance.canMoveAll == false)
        {
            scoreFinal = PlayerDistance.Instance.disRun;
            scoreEndText.text = scoreFinal.ToString();
            if (scoreFinal > PlayerDistance.Instance.DisHi)
            {
                PlayerPrefs.SetFloat("hiScore", scoreFinal);
                hiScoreText.text = scoreFinal.ToString();
            }
            else
            {
                hiScoreText.text = PlayerPrefs.GetFloat("hiScore").ToString();
            }
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
