using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : ObjectBase
{
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t++;
        if(t>120)
            ReleaseObject();
        Debug.Log(t);
    }
}
