using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public Material ScreenEffectMaterial;
    private float EnemyDown = 0f;
    private Color StartColor = new Color(1f, 1f, 1f);
    private Color EndColor = new Color(0.5f, 0f, 0f);

    public void OnObjectDestroyed()
    {
        EnemyDown = Mathf.Min(EnemyDown + 0.05f, 1f);
        Color CurrentColor = Color.Lerp(StartColor, EndColor, EnemyDown);
        ScreenEffectMaterial.SetColor("ScreenColor", CurrentColor);
    }

    void OnDisable()
    {
        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    }

    void OnApplicationQuit()
    {
        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    }
}