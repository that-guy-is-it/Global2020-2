using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyBois : MonoBehaviour
{
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        if (GM == null)
        {
            GM = GameObject.FindGameObjectWithTag("GameManager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player = GM.GetComponent<GameManager>().Player.GetComponent<BoxCollider2D>())
            Debug.Log("Hey Baby I'ma spikey boi");
        else
            Debug.Log("FMl");
    }
}
