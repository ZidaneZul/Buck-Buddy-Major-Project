using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    float horizontal;
    public float speed = 3f;
    float timer, seconds;
    public bool isFacingRight = true;
    bool isAFK;
    
    public bool movingLeft, movingRight;

    Rigidbody rb;
    public Animator anim;

    public Animator maleAnim, femaleAnim;

    public Sprite maleStanding, femaleStanding;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        anim = GetComponentInChildren<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if(!movingRight && !movingLeft)
            horizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontal);
        Flip();

        if(!(horizontal == 0))
        {
            anim.SetBool("Walking", true);
            timer = 0;
            anim.ResetTrigger("Stop");
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if(isAFK && horizontal == 0)
        {
            anim.SetBool("Walking", false);
            StartTimer();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);

        if (movingLeft)
        {
            //rb.velocity = new Vector3(-horizontal * speed, rb.velocity.y);
            horizontal = -1;
            anim.SetBool("Walking", true);
            timer = 0;
        }
        if (movingRight)
        {
            //rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
            horizontal = 1;
            anim.SetBool("Walking", true);
            timer = 0;
        }
    }

    void StartTimer()
    {
        if (isAFK)
        {
            timer += Time.deltaTime;

            if(timer > 2f)
            {
                anim.SetTrigger("Stop");
            }
        }
        
    }

    void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    public void MoveLeftDown()
    {
        movingLeft = true;
        isAFK = false;
       // Debug.Log("Moving left");
    }
    public void MoveLeftUp()
    {
        movingLeft = false;
        isAFK = true;
       // Debug.Log("stop left");
    }
    public void MoveRightDown()
    {
        movingRight = true;
        isAFK = false;
        //Debug.Log("Moving right");
    }
    public void MoveRightUp()
    {
        movingRight = false;
        isAFK = true;
        //Debug.Log("stop right");
    }
    
}
