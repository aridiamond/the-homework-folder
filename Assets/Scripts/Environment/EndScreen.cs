using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreEndText;
    public float scoreFinal;


    void Start()
    {
        if (PlayerMove.Instance.canMoveAll == false)
        {
            scoreFinal = PlayerDistance.Instance.disRun;
            scoreEndText.text = scoreFinal.ToString();
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
