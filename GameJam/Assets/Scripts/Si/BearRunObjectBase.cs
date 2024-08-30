using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearRunObjectBase : ObjectBase
{
    public bool Turn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public Vector3 rotationSpeed = new Vector3(30, 100,70); // ȸ�� �ӵ� ����

    // Update is called once per frame
    void Update()
    {
        if (Turn)
        // �� �����Ӹ��� ��ü�� ȸ����ŵ�ϴ�.
        transform.Rotate(rotationSpeed * Time.deltaTime);
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
        yield return new WaitForSeconds(0.3f);
        ReleaseObject();
    }
}
