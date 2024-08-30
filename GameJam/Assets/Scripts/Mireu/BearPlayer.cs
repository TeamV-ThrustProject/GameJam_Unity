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
        base.speed += 0.01f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            base.speed -= base.speed / 2;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            base.speed -= base.speed / 2;
            Destroy(collision.gameObject);
        }
    }

}
