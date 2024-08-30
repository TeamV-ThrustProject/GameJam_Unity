using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public Transform[] waypoints;
    public float forwardSpeed = 5f;
    public float rotationSpeed = 5f;
    public float waypointThreshold = 0.1f;
    public float sideForce = 10f;  // �¿� �̵��� ������ ��
    public float maxSideDistance = 2f;  // ��ηκ��� �ִ� �̵� ���� �Ÿ�

    private int currentWaypointIndex = 0;
    private Rigidbody rb;
    private Vector3 lastWaypointPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing!");
            enabled = false;
            return;
        }

        if (waypoints.Length > 0)
        {
            lastWaypointPosition = waypoints[0].position;
        }
    }

    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // ��������Ʈ ���󰡱�
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            // ���� �̵�
            transform.position += moveDirection * forwardSpeed * Time.deltaTime;

            // ȸ��
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // ���� ��������Ʈ�� �̵�
            if (Vector3.Distance(transform.position, targetPosition) < waypointThreshold)
            {
                lastWaypointPosition = waypoints[currentWaypointIndex].position;
                currentWaypointIndex++;
            }
        }
        else
        {
            // ��� ��������Ʈ�� ������� ���� ����
            currentWaypointIndex = 0;
        }

        // �¿� �̵� ó��
        AddForceChar();
    }

    void AddForceChar()
    {
        Vector3 rightDirection = Vector3.Cross(Vector3.up, transform.forward).normalized;
        Vector3 currentPosition = transform.position;
        Vector3 closestPointOnPath = GetClosestPointOnPath(currentPosition);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Vector3.Distance(currentPosition, closestPointOnPath) < maxSideDistance)
            {
                rb.AddForce(-rightDirection * sideForce);
                Debug.Log("Left");
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Vector3.Distance(currentPosition, closestPointOnPath) < maxSideDistance)
            {
                rb.AddForce(rightDirection * sideForce);
                Debug.Log("Right");
            }
        }
    }

    Vector3 GetClosestPointOnPath(Vector3 position)
    {
        Vector3 currentWaypoint = waypoints[currentWaypointIndex].position;
        Vector3 previousWaypoint = lastWaypointPosition;

        Vector3 pathDirection = (currentWaypoint - previousWaypoint).normalized;
        float distanceAlongPath = Vector3.Dot(position - previousWaypoint, pathDirection);

        return previousWaypoint + pathDirection * distanceAlongPath;
    }

    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        for (int i = 0; i < waypoints.Length; i++)
        {
            Gizmos.DrawSphere(waypoints[i].position, 0.5f);
            if (i < waypoints.Length - 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
    }
}