using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterPlayer : PlayerMovement
{
    Rigidbody CharRigidbody;
    private bool isGrounded = false;
    public float jumpForce = 5f;

    public Animator animator;
    protected override void Start()
    {
        base.Start();
        CharRigidbody = GetComponent<Rigidbody>();
        animator =  this.transform.GetChild(1).GetComponent<Animator>();
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
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJump", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsJump", true);
        }
    }
}
