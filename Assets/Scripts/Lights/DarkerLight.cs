using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkerLight : MonoBehaviour
{
    private int EnemiesDestroyed = 0;
    private int MaxEnemies = 8;

    public Light DirLight;
    //private Light DirLight;

    public float InitialIntensity = 1.2f;
    public float FinalIntensity = 0f;

    private void Start()
    {
        //DirLight = GetComponent<Light>();
        //DirLight = GameObject.Find("Directional Light")?.GetComponent<Light>();
        if (DirLight == null)
        {
            DirLight = GameObject.Find("Directional Light")?.GetComponent<Light>();
        }
        DirLight.intensity = InitialIntensity;
    }

    public void OnObjectDestroyed()
    {
        EnemiesDestroyed += 1;
        EnemiesDestroyed = Mathf.Clamp(EnemiesDestroyed, 0, MaxEnemies);
        float t = (float)EnemiesDestroyed / MaxEnemies;
        //Debug.Log($"EnemiesDestroyed: {EnemiesDestroyed}, t: {t}");
        if (DirLight != null)
        {
            DirLight.intensity = Mathf.Lerp(InitialIntensity, FinalIntensity, t);
            Debug.Log($"Updated intensity to {DirLight.intensity}");
        }
        else
        {
            Debug.LogError("DirLight no està assignada!");
        }
    }

}
