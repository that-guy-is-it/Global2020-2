using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public float direction = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(3 * direction, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
