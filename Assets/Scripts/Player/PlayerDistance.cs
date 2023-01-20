using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDistance : MonoBehaviour
{
    public float DisActual => PlayerMove.Instance.transform.position.z;
    public float disRun = 0f;
    public float disSubtract = 0f;
    public float disAdded = 0f;
    public bool startedPlaying = false;
    public TextMeshProUGUI scoreText;
    public static PlayerDistance Instance;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        } else Destroy(this);
    }

    void Start()
    {
        StartCoroutine(PlayStart());
    }


    void Update()
    {
        if (startedPlaying == true && PlayerMove.Instance.canMoveAll == true)
        {
            disRun = DisActual - disSubtract + disAdded;
            scoreText.text = disRun.ToString();
        }
    }

    IEnumerator PlayStart()
    {
        yield return new WaitForSeconds(2f);
        disSubtract = DisActual;
        startedPlaying = true;
    }

}
