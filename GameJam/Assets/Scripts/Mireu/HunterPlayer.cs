using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class HunterPlayer : PlayerMovement
{
    Rigidbody CharRigidbody;
    private bool CanJump = true;
    public float jumpForce = 1f;
    [SerializeField]
    GameObject Player;
    public Animator animator;
    protected override void Start()
    {
        base.Start();
        CharRigidbody = GetComponent<Rigidbody>();
        animator =  this.transform.GetChild(1).GetComponent<Animator>();
    }


    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyUp(KeyCode.Space) && CanJump)
        {
            CharRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            CanJump = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CanJump = true;
            animator.SetBool("IsJump", false);
        }
    }

        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MemoryTrg"))
        {
            Player.SetActive(true);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("turn"))
        {
            GameObject g = other.gameObject;
            Quaternion quat;
            Debug.Log("turnturn");
            GetComponent<PlayerMovement>().rotWeight += 5;
            quat = Quaternion.Euler(0, 5, 0);
            transform.forward = quat * transform.forward;
        }
        if (other.CompareTag("EndCutTrg"))
        {
            other.GetComponent<CutSceneController>().PlayCutScene();
        }
        if (other.CompareTag("CutTrg"))
        {
            other.GetComponent<CutSceneController>().PlayCutScene();
        }
    }
    private void OnEnable()
    {
        base.OnEnable();
        rotWeight = 90;
    }
}
