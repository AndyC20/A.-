using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controller : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigid;
    public float groundDistance = 0.3f;
    public float JumpForce = 250;
    public float ForwardForce = 500;
    public LayerMask whatIsGround;
    private Vector3 direction;
    public float rotationSpeed = 90.0f;
    public GameBehaviour gameManager;
   
    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        bool run = animator.GetBool("run");
        bool walk = animator.GetBool("walk");
        bool forward = Input.GetKey("w");
        bool shiftPress = Input.GetKey("left shift");
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical"); 

        
        RotateCharacter();

        // if the walk boolean is false and "w" is pressed then the chatacyer will move forward
        if (!walk && forward)
        {
            // set the walk boolean to true
            animator.SetBool("walk", true);
        }
        // when the player is no longer pressing "w", the character will stop
        if (walk && !forward)
        {
            animator.SetBool("walk", false);
        }

        // when shift is held while moving, the character wll start sprinting
        if (!run && (walk && shiftPress))
        {
            animator.SetBool("run", true);
        }
        // if "w" or "shift" is released then the character will stop sprinting
        if (run && (!walk || !shiftPress))
        {
            animator.SetBool("run", false);
        }

    void RotateCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rotation = Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }       

        if (Input.GetButtonDown("Jump"))
        {
            Vector3 jumpDirection = transform.forward * JumpForce + Vector3.up * JumpForce;
            rigid.AddForce(jumpDirection);
            animator.SetTrigger("Jump");
        }


        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, groundDistance, whatIsGround))
        {
            animator.SetBool("grounded", true);
            animator.applyRootMotion = true;
        }
        else
        {
            animator.SetBool("grounded", false);


            // if "w" is pressed whole the character is in air it'll move forward
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                rigid.AddForce(transform.forward * ForwardForce);
            }
        }
    }

    void OnCollisionEnter(Collision Other){
        if(Other.gameObject.CompareTag("collect")){
            Other.gameObject.SetActive(false);
            gameManager.Items += 1;
        }
    }
}
