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

    private ParticleSystem.MainModule mainModule;
    private Renderer objectRenderer;
    private Material[] objectMaterials;
    private float timer;

    void Start()
    {
        // Obtén el módulo principal del ParticleSystem
        mainModule = AiguaFont.main;

        // Establece el color inicial de las partículas (dos tonos de azul)
        mainModule.startColor = new ParticleSystem.MinMaxGradient(Blue1, Blue2);

        objectRenderer = GetComponent<Renderer>();
        objectMaterials = objectRenderer.materials;

        timer = 0f; // Inicia el temporizador
    }

    void Update()
    {
        // Contador para cambiar el color después de cierto tiempo
        timer += Time.deltaTime;

        if (timer >= changeTime)
        {
            // Cambiar el color de las partículas (dos tonos de rojo)
            mainModule.startColor = new ParticleSystem.MinMaxGradient(Red1, Red2);

            if (objectMaterials != null)
            {
                // Aquí buscamos el material de agua específico (fountain_oceanShader1)
                foreach (var material in objectMaterials)
                {
                    if (material.name.Contains("Fountain_oceanShader1")) // Verifica el nombre del material
                    {
                        Debug.Log("Ha llegado al material!");
                        // Cambia el color del material del agua
                        material.SetColor("_BaseColor", Red1);  // Cambia a rojo
                    }
                }
            }
        }
    }
}