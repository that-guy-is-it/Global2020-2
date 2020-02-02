using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAI : MonoBehaviour
{
    enum states { Hidden, Ready, Out };
    states currState = states.Out;
    bool flag = false;
    float timeFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            //change state
            currState += 1;

            timeFlag = Time.time + 3;
            if (currState > states.Out)
            {
                currState = 0;
            }
            print(currState.ToString());
            flag = false;

        } else
        {
            //wait three seconds
            if(Time.time > timeFlag)
            {
                flag = true;
            }
        }
    }
}
