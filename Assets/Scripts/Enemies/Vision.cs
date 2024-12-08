using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public float Range = 10;
    
    public Transform WayPoint;

    //private void OnDrawGizmos() //per veure el rang on es mes clarament
    //{
    //    Gizmos.DrawWireSphere(transform.position, Range);
    //}


    void Start()
    {

    }

    
    void Update()
    {
        Debug.Log(IsDetected());
                
    }

    public bool IsDetected()
    {
        if (IsInRange(WayPoint))
            return true;
        
        return false;
    }

    
    private bool IsInRange(Transform target)
    {
        return Vector3.Distance(transform.position, target.position) < Range;
        
    }
}
