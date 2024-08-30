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
        //Quaternion Rotation = Quaternion.Euler(transform.rotation.x, dir.x * horizontalRot, transform.rotation.z);
        
        //rb.MoveRotation(Rotation);
        rb.MovePosition(gameObject.transform.position + dir * speed * Time.deltaTime);
    }
}
