using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoading : MonoBehaviour
{
    private static DontDestroyOnLoading dont = null;

    // Start is called before the first frame update
    void Start()
    {
        if (dont == null)
        {
            DontDestroyOnLoad(this.gameObject);
            dont = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
