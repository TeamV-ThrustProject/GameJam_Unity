using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class TestSS : PlayerMovement
{
    Rigidbody CharRigidbody;
    public float jumpForce = 5f;
    public float maxChargeTime = 3.0f;

    private bool isGrounded = false;
    private bool isCharging = false;
    private float chargeStartTime;
    private float chargeTime = 0f;

    protected override void Start()
    {
        base.Start();
        CharRigidbody = GetComponent<Rigidbody>();
    }


    protected override void Update()
    {
        base.Update();
        HandleCharging();
        HandleJump();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    void HandleCharging()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isCharging = true;
            chargeStartTime = Time.time;
            Debug.Log("Charging Start");
        }

        if (Input.GetKey(KeyCode.Space) && isCharging)
        {
            chargeTime = Mathf.Min(Time.time - chargeStartTime, maxChargeTime);
            Debug.Log("Charging: " + chargeTime);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isCharging && isGrounded)
        {
            float jumpPower = jumpForce * (1 + chargeTime);
            CharRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isCharging = false;
            chargeTime = 0f;
            Debug.Log("Jump with power: " + jumpPower);
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
