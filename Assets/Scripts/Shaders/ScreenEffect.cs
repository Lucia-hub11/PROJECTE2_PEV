using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public Material ScreenEffectMaterial;  // El material con el shader de la viñeta

    private float effectDuration = 0.5f;  // Duración del efecto (en segundos)
    private float effectTimer = 0f;      // Temporizador para la duración del efecto
    private bool isEffectActive = false; // Bandera para saber si el efecto está activo

    private void Update()
    {
        if (isEffectActive)
        {
            Debug.Log("SE ACTIVA");
            effectTimer += Time.deltaTime;  // Acumulamos el tiempo del efecto

            // Interpolamos entre 0 (sin efecto) y 1 (máximo efecto)
            float lerpValue = effectTimer / effectDuration;
            Debug.Log("VignetteIntensity: " + lerpValue);
            // Aplicamos el valor interpolado al parámetro de intensidad en el shader (ej. "VignetteIntensity")
            ScreenEffectMaterial.SetFloat("VignetteIntensity", lerpValue);
            Debug.Log("VignetteIntensity: " + lerpValue);
            if (effectTimer >= effectDuration)
            {
                Debug.Log("Y SE DESACTIVA UE");
                // El efecto ha terminado, lo desactivamos
                isEffectActive = false;
                effectTimer = 0f;
                ScreenEffectMaterial.SetFloat("VignetteIntensity", 0f); // Desactivamos el efecto completamente
            }
        }
    }

    public void OnDamageTaken()
    {
        Debug.Log("recibe el daño!!");
        // Activamos el efecto cuando el jugador recibe daño
        isEffectActive = true;
        effectTimer = 0f; // Reiniciamos el temporizador
        ScreenEffectMaterial.SetFloat("VignetteIntensity", 1f); // Activamos el efecto al máximo
    }

    void OnDisable()
    {
        // Aseguramos que el efecto esté desactivado si el objeto se desactiva
        ScreenEffectMaterial.SetFloat("VignetteIntensity", 0f);
    }

    void OnApplicationQuit()
    {
        // Aseguramos que el efecto esté desactivado al cerrar la aplicación
        ScreenEffectMaterial.SetFloat("VignetteIntensity", 0f);
    }
}

    //public class ScreenEffect : MonoBehaviour
    //{
    //    public Material ScreenEffectMaterial;

    //    private Color StartColor = new Color(0f, 0f, 0f);
    //    private Color EndColor = new Color(0.3f, 1f, 1f);

    //    private float effectDuration = 0.8f; // Duración del efecto (en segundos)
    //    private float effectTimer = 0f; // Temporizador para la duración del efecto
    //    private bool isEffectActive = false; // Bandera para saber si el efecto está activo

    //    private void Update()
    //    {
    //        if (isEffectActive)
    //        {
    //            Debug.Log("ns que hace pero lo hace");
    //            effectTimer += Time.deltaTime; // Acumulamos el tiempo del efecto

    //            // Realizamos un Lerp entre StartColor y EndColor dependiendo del tiempo que ha pasado
    //            float lerpValue = effectTimer / effectDuration;
    //            Color currentColor = Color.Lerp(EndColor, StartColor, lerpValue);
    //            ScreenEffectMaterial.SetColor("ScreenColor", currentColor);

    //            if (effectTimer >= effectDuration)
    //            {
    //                Debug.Log("TIC TAC");
    //                isEffectActive = false; // El efecto ha terminado
    //                effectTimer = 0f; // Reiniciamos el temporizador
    //                ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    //            }
    //        }
    //    }

    //    public void OnDamageTaken()
    //    {
    //        Debug.Log("HA RECIBIDO EL DAÑO");
    //        // Cuando el jugador recibe daño, activamos el efecto
    //        isEffectActive = true;
    //        effectTimer = 0f; // Reiniciamos el temporizador
    //        ScreenEffectMaterial.SetColor("ScreenColor", EndColor);
    //    }

    //    void OnDisable()
    //    {
    //        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    //    }

    //    void OnApplicationQuit()
    //    {
    //        ScreenEffectMaterial.SetColor("ScreenColor", StartColor);
    //    }





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
    //}