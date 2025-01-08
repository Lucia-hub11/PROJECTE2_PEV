using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basement : MonoBehaviour
{
    public float DoorRange = 4;
    public Transform WayPoint;
    public Vector3 Offset;

    public Animator TrapdoorAnimator;
    bool open_trapdoor;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + Offset, DoorRange);
    }

    void Start()
    {
        open_trapdoor = false;
    }

    private int EnemiesDestroyed = 0;
    public void OnObjectDestroyed()
    {
        EnemiesDestroyed += 1;
        Debug.Log("UNO MAS UNO MENOS " + EnemiesDestroyed);
    }

    void Update()
    {
        if (IsBasementDetected() && EnemiesDestroyed == 8)
        {
            open_trapdoor = true;
            TrapdoorAnimator.SetBool("Trapdoor", open_trapdoor);
            Debug.Log("ABRETE SESAMO ");
        }
    }

    public bool IsBasementDetected()
    {
        return IsInBasementRange(WayPoint);
    }

    private bool IsInBasementRange(Transform target)
    {
        return Vector3.Distance(transform.position + Offset, target.position) < DoorRange;
    }
}
