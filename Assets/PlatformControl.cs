using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    private Rigidbody2D playerRB;
    public float moveForce = 250f;
    public float maxSpeed = 5f;
    public float jumpForce = 50f;
    public Transform groundCheck;
    public Transform from;
    public float speed = 0.1F;
    public float jumpvelocity;
    public Animator anim;
    private bool working = false;
   // public LayerMask groundMask = 1 << 8;

    private bool grounded = false;
   // private Animator anim;
    private Rigidbody2D rb2d;
    
    

  

    
    
    



    void Awake ()
    {

       // anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
     

        jumpvelocity = playerRB.velocity.y;

        if (jumpvelocity == 0)
        {
            grounded = true;
        }
        
        
            
        

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        Debug.Log(grounded);
        Debug.Log(transform.position);
        Debug.Log(groundCheck.position);
        Debug.Log(working);

    }
    void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");

            //anim.SetFloat("Speed", Mathf.Abs(h));

            if (h * rb2d.velocity.x < maxSpeed)
                rb2d.AddForce(Vector2.right * h * moveForce);

            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

            if (h > 0 && !facingRight)
                Flip();
            else if (h < 0 && facingRight)
                Flip();


            if(rb2d.velocity.x > 0 || rb2d.velocity.x < 0)
        {
            anim.Play("Bob2 0");
            working = true;
        } 
            else
        {
            anim.Play("Idle 0");
            working = false;
        }
            if(jump)
            {
               // anim.SetTrigger("Jump");
                rb2d.AddForce(new Vector2(0f, 400f));
                jump = false;
                grounded = false;
            }

        }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
		
   
    
	
}
