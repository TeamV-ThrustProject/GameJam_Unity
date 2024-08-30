using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrig : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;

    public float rot;

    Vector3 rotation;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject g = other.gameObject;
            camera.transform.SetParent(player.transform, false);
            g.GetComponent<PlayerMovement>().IsRotated = true;

            //g.transform.Rotate(0, other.gameObject.transform.rotation.y + rot, 0);
            Quaternion rotation = Quaternion.Euler(0, rot, 0);
            g.transform.forward = rotation * g.transform.forward;

            camera.transform.SetParent(null, false);
            g.GetComponent<PlayerMovement>().IsRotated = false;

            //camera.transform.forward = g.transform.position - camera.transform.position;
        }
    }
}
