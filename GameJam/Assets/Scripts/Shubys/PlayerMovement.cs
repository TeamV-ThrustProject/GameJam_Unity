using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float forwardSpeed = 1.0f;
    public float speed = 1.0f;
    
    Vector3 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        //dir.z = Input.GetAxisRaw("Vertical");
        dir.z = forwardSpeed;

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(gameObject.transform.position + dir * speed * Time.deltaTime);
    }
}
