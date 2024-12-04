using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public float Range = 10;
    

    

    public Transform WayPoint; //fa falta array si nomes fa falta 1 wp?

       

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

    public bool IsDetected()
    {
        if (!IsInRange(WayPoint))
            return false;
        

        return true;
    }

    
    private bool IsInRange(Transform target)//que es el target?
    {
        return Vector3.Distance(transform.position, target.position) < Range;
        
    }
}
