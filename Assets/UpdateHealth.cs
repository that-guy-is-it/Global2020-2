using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHealth : MonoBehaviour
{
    GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        if (GM == null)
        {
            GM = GameObject.FindGameObjectWithTag("GameManager");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(GM.GetComponent<GameManager>().Player.GetComponent<CharCont>().healthPoints == 2)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);

        }
        else if (GM.GetComponent<GameManager>().Player.GetComponent<CharCont>().healthPoints == 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (GM.GetComponent<GameManager>().Player.GetComponent<CharCont>().healthPoints == 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
