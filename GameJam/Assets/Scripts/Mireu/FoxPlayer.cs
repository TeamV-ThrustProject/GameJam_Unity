using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class FoxPlayer : PlayerMovement
{
    Rigidbody CharRigidbody;
    public float jumpForce = 5f;

    private bool isGrounded = false;
    private bool isCharging = false;
    private float chargeStartTime;
    private float chargeTime = 0f;
    public float maxChargeTime = 1.5f;

    public Animator animator;
    protected override void Start()
    {
        base.Start();
        CharRigidbody = GetComponent<Rigidbody>();
        animator = this.transform.GetChild(1).GetComponent<Animator>();
    }


    protected override void Update()
    {
        base.Update();
        HandleCharging();
        HandleJump();
    }
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 3, groundLayer);
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
            //Debug.Log("Charging Start");
        }

        if (Input.GetKey(KeyCode.Space) && isCharging)
        {
            chargeTime = Mathf.Min(Time.time - chargeStartTime, maxChargeTime);

            if (chargeTime > maxChargeTime)
            {
                chargeTime = maxChargeTime;
            }
            Debug.Log("Charging: " + chargeTime);
        }
    }




    void HandleJump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isCharging && isGrounded)
        {
            float chargeRatio = Mathf.Clamp01(chargeTime / maxChargeTime);
            float jumpPower = jumpForce * (1f + chargeRatio);

            CharRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            isCharging = false;
            chargeTime = 0f;
        }
    }
    

}
