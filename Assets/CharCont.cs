using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : MonoBehaviour
{

    public static float speed = 1.5f;
    public float jumpSpeed = 1.0f;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D rigid;
    private bool grounded = false;
    const float minMoveDistance = 0.001f;
    public bool movedRight = true;
    private Vector2 currVel;
    public bool onLadder = false;
    //[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        //grounded = 
        MoveCompute();
    }

    public void MoveCompute()
    {
        //if rolling...
        if (Input.GetKey("e"))
        {
            
            //print("Rolling...");
            if (movedRight)
            {
                print("Rolling Right...");
                //rigid.velocity = Vector2.SmoothDamp(rigid.velocity, new Vector2(speed, rigid.velocity.y), ref currVel, 0.02f);
                //rigid.velocity = new Vector2(speed * 4, 0);
                rigid.AddForce(transform.right * speed * 300);
            }
            else
            {
                print("Rolling Left...");
                //rigid.velocity = new Vector2(speed * -4, 0);
                rigid.AddForce(transform.right * speed * -300);

            }
        }
        //if jumping...

        //if neither...
        //Vector2 move = Vector2.zero;
        //move.x = Input.GetAxis("Horizontal");


        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            print("Right pressed");
            rigid.velocity = new Vector2(speed * 2, rigid.velocity.y);
            movedRight = true;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            print("Left pressed");
            rigid.velocity = new Vector2(speed * -2, rigid.velocity.y);
            movedRight = false;
        }
        else
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onLadder = false;
        rigid.gravityScale = 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onLadder = true;   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            print("On Ladder!");
            rigid.gravityScale = 0.0f;
            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                print("On ladder and going up");
                rigid.transform.position = new Vector3(rigid.transform.position.x, rigid.transform.position.y + 0.2f, 0.0f);
            } else if(Input.GetKey("down") || Input.GetKey("s"))
            {
                rigid.transform.position = new Vector3(rigid.transform.position.x, rigid.transform.position.y - 0.2f, 0.0f);
                print("On ladder and going down");
            }
        }
    }


    public void Jump()
    {
        grounded = false;
        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * 3);
        print("Jump pressed");

    }

    

}
