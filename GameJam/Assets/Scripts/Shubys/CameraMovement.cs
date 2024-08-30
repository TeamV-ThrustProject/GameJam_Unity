using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 posWeight;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 targetPos = player.position + posWeight;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 2f);
    }
}
