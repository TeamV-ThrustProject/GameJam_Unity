using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float forwardSpeed = 1.0f;
    public float speed = 1.0f;
    public float horizontalRot;
    
    Vector3 dir;
    public bool IsRotated;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        //dir.z = Input.GetAxisRaw("Vertical");
        dir.z = forwardSpeed;

    }

    protected virtual void FixedUpdate()
    {
        if(!IsRotated)
        {
            Quaternion Rotation = Quaternion.Euler(0, dir.x * horizontalRot, 0);

            rb.MoveRotation(Rotation);
        }

        

        rb.MovePosition(gameObject.transform.position + transform.forward * speed * Time.deltaTime);
    }
}
