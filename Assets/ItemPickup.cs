using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int stopHere = 0;
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharCont>().soundEffects.Play();
            Destroy(gameObject);
            GM.Player.GetComponent<CharCont>().pickupsNum += 1;
        }
    }
}
