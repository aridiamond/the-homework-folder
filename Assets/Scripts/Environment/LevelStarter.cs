using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] GameObject countDown3;
    [SerializeField] GameObject countDown2;
    [SerializeField] GameObject countDown1;
    [SerializeField] GameObject countDownX;
    [SerializeField] GameObject fadeIn;


    
    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.5f);
        countDown3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        countDownX.SetActive(true);
        PlayerMove.canMoveLR = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(fadeIn);
        Destroy(countDown3);
        Destroy(countDown2);
        Destroy(countDown1);
        Destroy(countDownX);
    }

}
