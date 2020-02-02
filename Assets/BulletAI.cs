using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public float direction = -1.0f;
    public float speed = 3.0f;
    Rigidbody2D rigid;
    public float countDown = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2((speed * direction), 0);
        countDown += 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > countDown)
        {
            Destroy(this);
        }
        
    }

    private void FixedUpdate()
    {
        //rigid.AddForce(Vector3.right * speed * direction);

        //transform.Translate(transform.position.x + direction * speed, transform.position.y, 0);

        //transform.position = new Vector3(transform.position.x + (speed * direction), transform.position.y);

        //rigid.velocity = new Vector2((speed * direction), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharCont>().TakeDamage();
        }
    }

}
