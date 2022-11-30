using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioSource footsteps;
    [SerializeField] private AudioSource jump;
    public Joystick joystick;
    private Vector2 pos;
    private Animator animator;
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    private Scene scene;
    private float axis;

    // Start is called before the first frame update
    void Start()
    {
        scene = GameObject.FindGameObjectWithTag("Scene").GetComponent<Scene>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = scene.lastcheckPoint;
    }

    // Update is called once per frame
    void Update()
    {
        // player horizontal movement
        pos = transform.position;
        axis = Input.GetAxis("Horizontal") + joystick.Horizontal;
        if(axis > 0)
        {
            pos.x += speed * Time.deltaTime;
        } 
        else if(axis < 0)
        {
            pos.x += -speed * Time.deltaTime;
        }
        else
        {
            pos.x += 0;
        }
        transform.position = pos;

        // setting up animation
        if (axis < 0)
        {
            animator.SetBool("isRunning", true);
            sp.flipX = true;
        }
        else if (axis > 0)
        {
            animator.SetBool("isRunning", true);
            sp.flipX = false;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (animator.GetBool("isRunning") && animator.GetBool("isGrounded"))
        {
            if (!footsteps.isPlaying)
                footsteps.Play();
        }
        else
        {
            footsteps.Stop();
        }

        //float verticalMove = joystick.Vertical;

        // player jump
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isGrounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isGrounded", false);
        }
    }

    public void Jump()
    {
        if (animator.GetBool("isGrounded"))
        {
            jump.Play();
            animator.SetTrigger("Jump");
            animator.SetBool("isGrounded", false);
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    public void Runleft()
    {
        axis = -1;
    }
    
    public void RunRight()
    {
        axis = 1;
    }

    public void Idle()
    {
        axis = 0;
    }
}
