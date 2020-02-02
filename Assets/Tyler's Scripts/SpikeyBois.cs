using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyBois : MonoBehaviour
{


    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
