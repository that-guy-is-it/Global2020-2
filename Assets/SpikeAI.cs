using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAI : MonoBehaviour
{
    enum states { Hidden, Ready, Out };
    states currState = states.Out;
    bool flag = false;
    float timeFlag;
    GameObject myself;
    public Collider2D collider;


    // Start is called before the first frame update
    void Start()
    {
        myself = this.gameObject;
        //collider = this.GetComponent<CompositeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            //change state
            currState += 1;

            if (currState > states.Out)
            {
                currState = 0;
            }
            //do state change...
            if (currState == states.Hidden)
            {
                collider.enabled = false;
                myself.transform.position = new Vector3 (0, -1, 0);
            }
            else if (currState == states.Ready)
            {
                myself.transform.position = new Vector3(0, -0.5f, 0);
                collider.enabled = false;
                print(collider.enabled);
            }
            else if (currState == states.Out)
            {
                collider.enabled = true;
                myself.transform.position = new Vector3(0, 0, 0);
                print(collider.enabled);
            }


            timeFlag = Time.time + 3;
            print(currState.ToString());
            flag = false;


        } else
        {
            //wait three seconds
            if(Time.time > timeFlag)
            {
                flag = true;
            } else
            {
                //print(Time.time);
            }
        }
    }
}
