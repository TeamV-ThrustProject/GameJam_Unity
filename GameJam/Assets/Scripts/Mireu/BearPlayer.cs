using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BearPlayer : PlayerMovement
{
    Rigidbody CharRigidbody;
    

    protected override void Start()
    {
        base.Start();
        CharRigidbody = GetComponent<Rigidbody>();
    }


    protected override void Update()
    {
        base.Update();
        if(Hp <= 0)
        {
            GetComponent<CutSceneController>().PlayCutScene();
            speed = 0;
        }
    }


}
