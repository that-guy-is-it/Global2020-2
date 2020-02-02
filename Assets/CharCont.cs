using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharCont : MonoBehaviour
{

    public float speed = 1.5f;
    public float jumpSpeed = 1.0f;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D rigid;
    private bool grounded = false;
    const float minMoveDistance = 0.001f;
    public bool movedRight = true;
    private Vector2 currVel;
    public bool onLadder = false;
    public GameObject pickupObject;
    public int healthPoints = 3;
    private bool messagePrinted = false;
    public int pickupsNum = 0;
    const int pickupsTarget = 3;
    public bool invincible;
    private bool isHit = false;
    float countdown;
    private bool rolled = false;
    private float rollTime = 0;
    float curTime = 0;
    float nextDamage = 1;
    public GameObject Igor;
    Animator anim;
    private bool grabbedPickupForLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = Igor.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (pickupsNum == pickupsTarget)
        {
            print("You got them all!");
        }

        //grounded = 
        if (healthPoints == 0 && messagePrinted)
        {
            messagePrinted = true;
            print("Git gud lol");
        }

        if (isHit == true)
        {
            InvincibilityFrames(3);
        }
        CheckInvinsibility();

        MoveCompute();

    }

    public void CheckInvinsibility()
    {
        if (Time.time > countdown)
        {
            invincible = false;
            isHit = false;
        }
    }

    public void MoveCompute()
    {
        //if rolling...
        if (Input.GetKey("e"))
        {
            if (rolled == true)
            {
                Debug.Log("Added 1 second");
                InvincibilityFrames(0.2f);
                rollTime = Time.time + 1;
                rolled = false;
            }
            else
            {
                //print("Rolling...");
                if (movedRight && Time.time > rollTime)
                {
                    //print("Rolling Right...");
                    //rigid.velocity = Vector2.SmoothDamp(rigid.velocity, new Vector2(speed, rigid.velocity.y), ref currVel, 0.02f);
                    //rigid.velocity = new Vector2(speed * 4, 0);
                    rigid.AddForce(transform.right * speed * 3000);
                    if (Time.time > rollTime)
                        rolled = true;
                }
                else if (Time.time > rollTime)
                {
                    //print("Rolling Left...");
                    //rigid.velocity = new Vector2(speed * -4, 0);
                    rigid.AddForce(transform.right * speed * -3000);
                    if (Time.time > rollTime)
                        rolled = true;
                }
            }
        }

        //if jumping...

        //if neither...
        //Vector2 move = Vector2.zero;
        //move.x = Input.GetAxis("Horizontal");


        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            //print("Right pressed");
            anim.SetTrigger("Walk");
            rigid.velocity = new Vector2(speed * 2, rigid.velocity.y);
            movedRight = true;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {

            anim.SetTrigger("WalkIgor");
            //print("Left pressed");
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
        //print("Trigger acted upon");
        if (collision.gameObject.tag == "Ladder")
        {
            onLadder = true;
        }
        else if (collision.gameObject.tag == "Pickup")
        {
            //if grabbed the pickup...
            grabbedPickupForLevel = true;
            GameObject.Destroy(pickupObject);

        }
        else if (collision.gameObject.tag == "Spikes")
        {
            TakeDamage();
        }
        else if (collision.gameObject.tag == "Finish" && grabbedPickupForLevel)
        {
            print("You win!");
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
        else if (collision.gameObject.tag == "Laser")
        {
            /*if (healthPoints > 0)
            {
                if (!invincible)
                {
                    //healthPoints--;
                    DecreaseHealth();
                    isHit = true;
                }
                print(healthPoints);
            }*/
            TakeDamage();
        }
        else if (collision.gameObject.tag == "Finish" && grabbedPickupForLevel)
        {
            print("You win!");
        }
    }

    public void TakeDamage()
    {
        if (!invincible)
        {
            if (healthPoints > 0)
            {
                if (!invincible)
                {
                    //healthPoints--;
                    DecreaseHealth();
                    isHit = true;
                }
                print(healthPoints);
            }
            else if (healthPoints <= 0)
            {
                SceneManager.LoadScene("Death");
            }
            if (movedRight)
            {
                rigid.AddForce((transform.right + transform.up) * 250);
            }
            else
            {
                //* 500
                rigid.AddForce((transform.right + transform.up) * 250);
            }
        }
    }

    private void InvincibilityFrames(float timeDelay)
    {
        if (invincible)
        {
            if (Time.time > countdown)
            {
                invincible = false;
                isHit = false;
            }
        }
        else
        {
            //countdown = Time.time + timeDelay;
            countdown = Time.time + 2;
            Debug.Log("added 2 second of invulnerablility");
            invincible = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            //print("On Ladder!");
            rigid.gravityScale = 0.0f;
            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                //print("On ladder and going up");
                rigid.transform.position = new Vector3(rigid.transform.position.x, rigid.transform.position.y + 0.2f, 0.0f);
            }
            else if (Input.GetKey("down") || Input.GetKey("s"))
            {
                rigid.transform.position = new Vector3(rigid.transform.position.x, rigid.transform.position.y - 0.2f, 0.0f);
                //print("On ladder and going down");
            }
        }
    }


    public void Jump()
    {
        grounded = false;
        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * 3);
        //print("Jump pressed");

    }

    private void DecreaseHealth()
    {
        if (curTime <= 0)
        {
            Debug.Log("Damage");
            healthPoints--;
            curTime = nextDamage;
        }
        else
        {

            curTime -= .5f;
        }
    }
}

