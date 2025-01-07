using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokeLantern : MonoBehaviour
{
    public float LanternRange = 4;
    public Transform WayPoint;
    public Vector3 Offset;

    public Animator LanternAnimator;
    bool broke_lantern;

    void Start()
    {
        broke_lantern = false;
    }

    private int EnemiesDestroyed = 0;
    public void OnObjectDestroyed()
    {
        EnemiesDestroyed += 1;
    }

    void Update()
    {
        if (IsLanternDetected() && EnemiesDestroyed >= 4)
        {
            broke_lantern = true;
            LanternAnimator.SetBool("Near Lantern", broke_lantern);
        }
    }

    public bool IsLanternDetected()
    {
        return IsInLanternRange(WayPoint);
    }

    private bool IsInLanternRange(Transform target)
    {
        return Vector3.Distance(transform.position + Offset, target.position) < LanternRange;
    }
}