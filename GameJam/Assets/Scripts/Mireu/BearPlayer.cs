using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BearPlayer : PlayerMovement
{
    Rigidbody CharRigidbody;
    
    public int BearHealth;

    protected override void Start()
    {
        base.Start();
        CharRigidbody = GetComponent<Rigidbody>();
        BearHealth = 3;
    }


    protected override void Update()
    {
        base.Update();
        base.speed += 0.01f;
        if(BearHealth <= 0)
        {
            Debug.Log("Dead");
            //Destroy(CharRigidbody.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            // µ¹ ÆÄ±« ÀÌÆåÆ® Ãß°¡
            base.speed -= base.speed / 2;
            BearHealth -= 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Tree"))
        {
            // ³ª¹« ÆÄ±« ÀÌÆåÆ® Ãß°¡
            Destroy(other.gameObject);
        }
    }


}
