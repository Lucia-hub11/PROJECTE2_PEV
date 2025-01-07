using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public Material ScreenEffectMaterial;

    private Color StartColor = new Color(1f, 1f, 1f);
    private Color EndColor = new Color(0.7f, 0f, 0f);


    private float effectDuration = 0.5f; // Duración del efecto (en segundos)
    private float effectTimer = 0f; // Temporizador para la duración del efecto
    private bool isEffectActive = false; // Bandera para saber si el efecto está activo

    private void Update()
    {
        if (isEffectActive)
        {
            Debug.Log("ns que hace pero lo hace");
            effectTimer += Time.deltaTime; // Acumulamos el tiempo del efecto

            if (effectTimer >= effectDuration)
            {
                Debug.Log("TIC TAC");
                isEffectActive = false; // El efecto ha terminado
                effectTimer = 0f; // Reiniciamos el temporizador
            }

            // Realizamos un Lerp entre StartColor y EndColor dependiendo del tiempo que ha pasado
            float lerpValue = effectTimer / effectDuration;
            Color currentColor = Color.Lerp(EndColor, StartColor, lerpValue);
            ScreenEffectMaterial.SetColor("ScreenColor", currentColor);
        }
    }

    public void OnDamageTaken()
    {
        Debug.Log("HA RECIBIDO EL DAÑO");
        // Cuando el jugador recibe daño, activamos el efecto
        isEffectActive = true;
        effectTimer = 0f; // Reiniciamos el temporizador
    }


    //public void OnDamageTaken()
    //{
    //    //Color CurrentColor = Color.Lerp(StartColor, EndColor);
    //    //ScreenEffectMaterial.SetColor("ScreenColor", CurrentColor);
    //}

    void OnDisable()
    {
        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    }

    void OnApplicationQuit()
    {
        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    }

    



    // SCRIPT PRIMERA VERSIÓ (ambient cada cop més vermell a mesura que es maten conills)

    //private float EnemyDown = 0f;
    //private Color StartColor = new Color(1f, 1f, 1f);
    //private Color EndColor = new Color(0.5f, 0f, 0f);

    //public void OnObjectDestroyed()
    //{
    //    EnemyDown = Mathf.Min(EnemyDown + 0.05f, 1f);
    //    Color CurrentColor = Color.Lerp(StartColor, EndColor, EnemyDown);
    //    ScreenEffectMaterial.SetColor("ScreenColor", CurrentColor);
    //}

    //void OnDisable()
    //{
    //    ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    //}

    //void OnApplicationQuit()
    //{
    //    ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    //}
}