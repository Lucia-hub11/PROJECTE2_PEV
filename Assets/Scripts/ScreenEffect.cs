using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public Material ScreenEffectMaterial;


    public void ChangeColor(float r, float g, float b)
    {
        Color newColor = new Color(r, g, b);
        ScreenEffectMaterial.SetColor("ScreenColor", newColor);
    }

}