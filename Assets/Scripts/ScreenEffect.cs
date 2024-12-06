using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public Material ScreenEffectMaterial;
    private float destructionCount = 0f;  // Contador de destrucción
    private Color startColor = new Color(1f, 1f, 1f);  // Blanco
    private Color endColor = new Color(1f, 0f, 0f);  // Rojo

    // Este método se llama cada vez que un GameObject es destruido
    public void OnObjectDestroyed()
    {
        // Aseguramos que no se pase del 1 (completamente rojo)
        destructionCount = Mathf.Min(destructionCount + 0.1f, 1f);

        // Interpolamos el color según el contador de destrucción
        Color currentColor = Color.Lerp(startColor, endColor, destructionCount);

        // Aplicamos el color al material
        ScreenEffectMaterial.SetColor("ScreenColor", currentColor);
    }
}

//public class ScreenEffect : MonoBehaviour
//{
//    public Material ScreenEffectMaterial;


//    public void ColorEffect(float r, float g, float b)
//    {
//        Color newColor = new Color(1f, 0f, 0f);
//        ScreenEffectMaterial.SetColor("ScreenColor", newColor);
//    }

//}