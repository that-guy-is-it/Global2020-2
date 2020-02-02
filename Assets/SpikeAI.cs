using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpikeAI : MonoBehaviour
{
    enum states { Hidden, Ready, Out };
    states currState = states.Out;
    bool flag = false;
    float timeFlag;
    GameObject myself;
    public List<Collider2D> colliders;

    // Start is called before the first frame update
    void Start()
    {
        myself = this.gameObject;
        colliders = this.GetComponents<Collider2D>().ToList();
        //collider = this.GetComponent<CompositeCollider2D>();
    }

    void toggleColliders(bool toToggle)
    {

        foreach(Collider2D col in colliders)
        {
            col.enabled = toToggle;
        }
        
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
                toggleColliders(false);
                myself.transform.position = new Vector3 (0, -1, 0);
            }
            else if (currState == states.Ready)
            {
                myself.transform.position = new Vector3(0, -0.5f, 0);
                toggleColliders(false);
                //print(collider.enabled);
            }
            else if (currState == states.Out)
            {
                toggleColliders(true);
                myself.transform.position = new Vector3(0, 0, 0);
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
