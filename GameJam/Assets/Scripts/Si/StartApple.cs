using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartApple : MonoBehaviour
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
            GameManager.GameManagerInstance.Stage = 2;
            GameManager.GameManagerInstance.Delay = 20;
        }
    }
}
