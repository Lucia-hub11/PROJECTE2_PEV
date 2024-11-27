using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public float Range = 10;
    public float FieldOfView = 60;

    public Transform Player;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsDetected());
    }

    bool IsDetected()
    {
        if (!IsInRange(Player))
            return false;
        if (!IsInFOV(Player))
            return false;

        return true;
    }

    private bool IsInFOV(Transform player)
    {
        Vector3 f=transform.forward;
        Vector3 p=player.position - transform.position;
        float anglePlayer = Vector3.Angle(f,p); //no acabo dentendre lo del angle, suposo que forward pq miri angle del seu davant i lo altre ns benb
        return anglePlayer < FieldOfView/2; //no acabo dentendre lo del return
    }

    private bool IsInRange(Transform target)//que es el target?
    {
        return Vector3.Distance(transform.position, target.position) < Range;
    }
}
