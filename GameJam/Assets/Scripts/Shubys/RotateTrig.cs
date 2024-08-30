using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotateTrig : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;

    public float rot;

    Vector3 rotation;
    bool once;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !once)
        {
            once = true;
            GameObject g = other.gameObject;
            
            StartCoroutine(MoveCamera(g));

        }
    }

    IEnumerator MoveCamera(GameObject player)
    {
        /*mainCamera.GetComponent<CameraMovement>().enabled = false;
        mainCamera.transform.SetParent(player.transform, true);*/
        //player.GetComponent<PlayerMovement>().IsRotated = true;


        for (int i = 1; i < rot; i+=5)
        {
            yield return new WaitForSeconds(0.001f);
            player.GetComponent<PlayerMovement>().rotWeight += i;
            Quaternion rotation = Quaternion.Euler(0, i, 0);
            //player.transform.forward = rotation * player.transform.forward;
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation,
                 rotation * transform.rotation, Time.deltaTime * 5f);
        }
        //player.GetComponent<PlayerMovement>().IsRotated = false;
        /*mainCamera.transform.SetParent(null, true);        
        mainCamera.GetComponent<CameraMovement>().enabled = true;*/
    }
}
