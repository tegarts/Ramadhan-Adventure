using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    // private float jumpForce =10;
    public float jumpWaitTime;
    private float jumpWaitTimer;
    public LayerMask ground;
    public Collider2D colliderKaki;
    private bool isGrounded;
    // private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    public Animator anim;
    [SerializeField] AudioClip jumpSound;
   
   void Start()
   {
    rb2D = gameObject.GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();

    moveSpeed = 1.8f;
    // jumpForce = 20f;
    // isJumping = false;
   }
    void Update()
    {
    moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical"); 
        if(Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.PlaySound(jumpSound);
        }
        /*  ini */
    }
    void FixedUpdate() {
        
       isGrounded = colliderKaki.IsTouchingLayers(ground);
        rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse); /* ini */
        if(moveHorizontal > 0.1f)
        {
            transform.localScale = new Vector3(7, 7, 7);
                    } else if(moveHorizontal < -0.1f){
            
            transform.localScale = new Vector3(-7, 7, 7);
        }

        if(moveVertical > 0.1f)
        {
          
        //    if (isGrounded)            /* ini */
        //     {
                
        //     Jump();
        //     }
            
            
        } else {
            
        }
       anim.SetBool("isWalking", moveHorizontal != 0);
    }

    // void Jump()
    // {
    //     rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);           /* ini */
        
    // }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Platform")
        {
            // isJumping = false;
            anim.SetBool("isJump", false);

            // if(jumpWaitTimer > 0f)
            // {
            //     jumpWaitTimer -= Time.deltaTime;
            // }
        }
    }
    void OnTriggerExit2D(Collider2D collision) {
        
        if(collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Platform")
        {
            // isJumping = true;
            anim.SetBool("isJump", true);
            // jumpWaitTimer = jumpWaitTime;
        }
    }

   

}
