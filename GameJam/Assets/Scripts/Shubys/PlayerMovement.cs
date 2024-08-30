using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float forwardSpeed = 1.0f;
    public float speed = 1.0f;
    public float horizontalRot;
    public bool IsRotated;
    public float rotWeight = 0;

    Vector3 dir;
    


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        //transform.localPosition.
        dir.x = Input.GetAxis("Horizontal");
        //dir.z = Input.GetAxisRaw("Vertical");
        dir.z = forwardSpeed;

    }

    protected virtual void FixedUpdate()
    {
        Quaternion rotation = Quaternion.Euler(0,0,0);
        if (!IsRotated)
        {
            rotation = Quaternion.Euler(0, rotWeight, 0);
            //Quaternion Rotation = Quaternion.Euler(0, rotWeight + dir.x * horizontalRot, 0);

            rb.MoveRotation(rotation);
        }

        Vector3 hori = new Vector3(dir.x, 0, 0);
        hori = rotation * hori;
        rb.MovePosition(gameObject.transform.position + (transform.forward + hori) * speed * Time.deltaTime);
        //rb.MovePosition(gameObject.transform.position + transform.forward * speed * Time.deltaTime);
    }
}
