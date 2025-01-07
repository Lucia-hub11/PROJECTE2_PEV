using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basement : MonoBehaviour
{
    public float DoorRange = 4;
    public Transform WayPoint;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DoorRange);
    }

    private int EnemiesDestroyed = 0;
    public void OnObjectDestroyed()
    {
        EnemiesDestroyed += 1;
        Debug.Log("UNO MAS UNO MENOS " + EnemiesDestroyed);

    }

    void Update()
    {
        if (IsBasementDetected() && EnemiesDestroyed == 7)
        {
            //Destroy(gameObject);
            //AQUI VA LA ANIMACIÓN
            Debug.Log("ABRETE SESAMO ");
        }
    }

    public bool IsBasementDetected()
    {
        return IsInBasementRange(WayPoint);
    }

    private bool IsInBasementRange(Transform target)
    {
        return Vector3.Distance(transform.position, target.position) < DoorRange;
    }
}
