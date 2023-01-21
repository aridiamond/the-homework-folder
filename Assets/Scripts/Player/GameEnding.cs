using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] GameObject lvlEnd;
    [SerializeField] AudioSource dedSfx;
    [SerializeField] AudioSource bgm;
    [SerializeField] GameObject playerModel;
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
        rb.useGravity = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            PlayerMove.Instance.canMoveAll = false;
            playerModel.GetComponent<Animator>().Play("ded");
            rb.useGravity = false;
            rb.freezeRotation = false; 
            StartCoroutine(GameEnd());
        }


    }

    IEnumerator GameEnd()
    {
        bgm.volume = 0.5f;
        yield return new WaitForSeconds(0.5f);
        dedSfx.Play();
        yield return new WaitForSeconds(1f);
        Cursor.visible = true;
        lvlEnd.SetActive(true);
    }
}
