using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPlayer : PlayerMovement
{
    Rigidbody CharRigidbody;
    private bool isGrounded = false;
    public float jumpForce = 5f;

    protected override void Start()
    {
        base.Start();
        CharRigidbody = GetComponent<Rigidbody>();
    }


    protected override void Update()
    {
        base.Update();
        HandleJump();
    }

    void HandleJump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            CharRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
