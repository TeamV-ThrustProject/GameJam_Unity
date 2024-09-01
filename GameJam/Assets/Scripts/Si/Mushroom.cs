using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.name.Equals("PlayerBaseHunter"))
                gameObject.SetActive(false);
            else
                other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 20, ForceMode.Impulse);

        }
    }
}
