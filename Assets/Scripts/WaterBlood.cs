using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlood : MonoBehaviour
{
    public ParticleSystem AiguaFont;
    public Color Blue1 = new Color(0.18f, 0.67f, 0.85f);
    public Color Blue2 = new Color(0.37f, 0.74f, 0.82f);
    public Color Red1 = new Color(1f, 0f, 0f);
    public Color Red2 = new Color(0.5f, 0f, 0f);
    public float changeTime = 5f;
    public float SmoothTime = 2f;

    private ParticleSystem.MainModule mainModule;
    private Renderer objectRenderer;
    private Material[] objectMaterials;
    private float timer;
    private float SmoothingTimer;
    private Color currentColor;

    void Start()
    {
        mainModule = AiguaFont.main;

        mainModule.startColor = new ParticleSystem.MinMaxGradient(Blue1, Blue2);

        objectRenderer = GetComponent<Renderer>();
        objectMaterials = objectRenderer.materials;

        timer = 0f;
        SmoothingTimer = 0f;
        currentColor = Blue1;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeTime && SmoothingTimer <= SmoothTime)
        {
            mainModule.startColor = new ParticleSystem.MinMaxGradient(Red1, Red2);

            if (objectMaterials != null)
            {
                foreach (var material in objectMaterials)
                {
                    if (material.name.Contains("Fountain_oceanShader1"))
                    {
                        Debug.Log("Ha llegado al material!");

                        SmoothingTimer += Time.deltaTime;
                        float t = Mathf.Clamp01(SmoothingTimer / SmoothTime);

                        Color newColor = Color.Lerp(currentColor, Red1, t);

                        material.SetColor("_BaseColor", newColor);
                    }
                }
            }
        }
    }
}