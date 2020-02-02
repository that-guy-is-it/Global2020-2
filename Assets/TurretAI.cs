using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{

    public bool isShootingRight = true;
    public GameObject bulletPrefab;
    public bool readyToShoot = false;
    public float nextShot = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToShoot)
        {
            //print("Ready!");
            //shoot
            GameObject bullet = GameObject.Instantiate(bulletPrefab, new Vector2 (transform.position.x, transform.position.y), new Quaternion());
            if (!isShootingRight)
            {
                bullet.GetComponent<BulletAI>().direction *= -1.0f;
            }
            //set the time
            nextShot = Time.time + 2.5f;
            readyToShoot = false;

        } else
        {
            //print("Waiting!");
            //do the countdown
            if (Time.time > nextShot)
            {
                readyToShoot = true;
            }
        }
    }
}
