using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public float Range = 10;
    

    public Transform Player;

    public Transform[] WayPoint; //fa falta array si nomes fa falta 1 wp?

    private int WP_Index;

    Transform WP => WayPoint[WP_Index]; //fa falta? es que com que nomes és 1
    

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
        

        return true;
    }

    
    private bool IsInRange(Transform target)//que es el target?
    {
        return Vector3.Distance(transform.position, target.position) < Range;
        transform.LookAt(WP);
    }
}
