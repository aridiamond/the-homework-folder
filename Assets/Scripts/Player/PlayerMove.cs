using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] bool isGrounded;
    [SerializeField] float leftRightSpeed = 10f;
    [SerializeField] float jumpHeight = 750f;
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 15f;
    
    public static PlayerMove Instance;
    static public bool canMoveLR = false;
    public bool canMoveAll = true;
    float moveSpeedIncr = 0.01f;
    private bool spdIncrActive = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else Destroy(this);
    }

    void Start()
    {
        // make sure these are true at start
        rb.freezeRotation = true;
        rb.useGravity = true;
    }
    
    void Update()
    {
       if (canMoveAll == true)
       {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World); 

            isGrounded = Physics.CheckSphere(transform.position, 0.76f, groundLayers, QueryTriggerInteraction.Ignore);
            
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

                if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)))
                {
                    rb.AddForce(Vector3.up * jumpHeight);
                }

                if (spdIncrActive == false)
                {
                    spdIncrActive = true;
                    StartCoroutine(SpdIncr());
                }

            }

            
        }
       
    }

    IEnumerator SpdIncr()
    {
        moveSpeed += moveSpeedIncr;
        yield return new WaitForSeconds(0.1f);
        spdIncrActive = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            rb.useGravity = false;
            rb.freezeRotation = false; 
            canMoveAll = false;
        }
    }
}
