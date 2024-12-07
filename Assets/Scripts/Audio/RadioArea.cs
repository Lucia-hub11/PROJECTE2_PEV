using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioArea : MonoBehaviour
{
    public float RadioRange = 4;

    public Transform WayPoint;

    private void OnDrawGizmos() //per veure el rang on es mes clarament
    {
        Gizmos.DrawWireSphere(transform.position, RadioRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsRadioDetected());
        //if (IsRadioDetected())
        //{
        //    Debug.Log("radioSi");
        //}
        //else
        //{
        //    Debug.Log("radioNO");
        //}
    }

    public bool IsRadioDetected()
    {
        if (IsInRadioRange(WayPoint))
        {
            return true;
        }
        return false;
    }
    private bool IsInRadioRange(Transform target)
    {
        return Vector3.Distance(transform.position, target.position) < RadioRange;
    }
}
