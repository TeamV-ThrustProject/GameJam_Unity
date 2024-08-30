using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearRunObjectBase : ObjectBase
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
        if (other.gameObject.CompareTag("End"))
        {
            ReleaseObject();
        }
    }

    public void SetRelease()
    {
        StartCoroutine(StartRelease());
    }

    IEnumerator StartRelease()
    {
        yield return new WaitForSeconds(1);
        ReleaseObject();
    }
}
