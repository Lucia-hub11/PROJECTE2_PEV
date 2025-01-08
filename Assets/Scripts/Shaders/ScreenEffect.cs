using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public Material ScreenEffectMaterial;

    private Color StartColor = new Color(0f, 0f, 0f);
    private Color EndColor = new Color(0.3f, 1f, 1f);

    private float effectDuration = 0.8f;
    private float effectTimer = 0f;
    private bool isEffectActive = false;

    private void Update()
    {
        if (isEffectActive)
        {
            effectTimer += Time.deltaTime;

            float lerpValue = effectTimer / effectDuration;
            Color currentColor = Color.Lerp(EndColor, StartColor, lerpValue);
            ScreenEffectMaterial.SetColor("ScreenColor", currentColor);

            if (effectTimer >= effectDuration)
            {
                isEffectActive = false;
                effectTimer = 0f;
                ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
            }
        }
    }

    public void OnDamageTaken()
    {
        isEffectActive = true;
        effectTimer = 0f;
        ScreenEffectMaterial.SetColor("ScreenColor", EndColor);
    }

    void OnDisable()
    {
        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    }

    void OnApplicationQuit()
    {
        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    }

    //SCRIPT PRIMERA VERSIÓ (ambient cada cop més vermell a mesura que es maten conills)

    //private float EnemyDown = 0f;
    //    private Color StartColor = new Color(1f, 1f, 1f);
    //    private Color EndColor = new Color(0.5f, 0f, 0f);

    //    public void OnObjectDestroyed()
    //    {
    //        EnemyDown = Mathf.Min(EnemyDown + 0.05f, 1f);
    //        Color CurrentColor = Color.Lerp(StartColor, EndColor, EnemyDown);
    //        ScreenEffectMaterial.SetColor("ScreenColor", CurrentColor);
    //    }

    //    void OnDisable()
    //    {
    //        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    //    }

    //    void OnApplicationQuit()
    //    {
    //        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    //    }
}