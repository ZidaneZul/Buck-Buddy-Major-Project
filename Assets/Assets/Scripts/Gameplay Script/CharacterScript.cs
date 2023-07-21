using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    float horizontal;
    public float speed = 3f;
    public bool isFacingRight = true; 
    
    public bool movingLeft, movingRight;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(!movingRight && !movingLeft)
            horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontal);
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);

        if (movingLeft)
        {
            //rb.velocity = new Vector3(-horizontal * speed, rb.velocity.y);
            horizontal = -1;
        }
        if (movingRight)
        {
            //rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
            horizontal = 1;
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
        Debug.Log("Moving left");
    }
    public void MoveLeftUp()
    {
        movingLeft = false;
        Debug.Log("stop left");
    }
    public void MoveRightDown()
    {
        movingRight = true;
        Debug.Log("Moving right");
    }
    public void MoveRightUp()
    {
        movingRight = false;
        Debug.Log("stop right");
    }
    
}
