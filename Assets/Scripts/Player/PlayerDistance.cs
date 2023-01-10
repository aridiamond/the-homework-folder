using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public float disActual => PlayerMove.Instance.transform.position.z;
    public float disRun = 0f;
    public float disSubtract = 0f;
    public bool startedPlaying = false;
    public TextMeshProUGUI scoreText;
    
    void Start()
    {
        StartCoroutine(PlayStart());
    }


    void Update()
    {
        disRun = disActual - disSubtract;
        if (startedPlaying == true && PlayerMove.Instance.canMoveAll == true)
        {
           scoreText.text = disRun.ToString();
        }
    }

    IEnumerator PlayStart()
    {
        yield return new WaitForSeconds(2f);
        disSubtract = disActual;
        startedPlaying = true;
    }
}
