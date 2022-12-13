using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;

    public float moveSpeed = 15;
    public float leftRightSpeed = 10;
    static public bool canMoveLR = false;
    public bool canMoveAll = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else Destroy(this);
    }

    void Update()
    {
       if (canMoveAll == true)
       {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World); 
            if (canMoveLR == true) 
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    if (this.gameObject.transform.position.x > LevelBoundary.leftSide) 
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                    }
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                    }
                }
            }
        }
       
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            canMoveAll = false;
        }
    }
}
