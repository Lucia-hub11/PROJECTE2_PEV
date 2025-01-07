using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngrierBunnies : MonoBehaviour
{
    private int EnemiesDestroyed = 0;
    private int MaxEnemies = 8;

    public Material BunnyMaterialWhite;
    public Material BunnyMaterialPink;
    public Material BunnyMaterialBlack;

    public Color InitialColorWhite = Color.white;
    public Color InitialColorPink = Color.red;
    public Color InitialColorBlack = Color.black;

    public Color TargetColorRed = Color.red;
    public Color TargetColorBlack = Color.black;

    
    public void OnObjectDestroyed()
    {
        EnemiesDestroyed += 1;
        EnemiesDestroyed = Mathf.Clamp(EnemiesDestroyed, 0, MaxEnemies);
        float t = (float)EnemiesDestroyed / MaxEnemies;
        Color newWhiteColor = Color.Lerp(InitialColorWhite, TargetColorBlack, t);
        Color newPinkColor = Color.Lerp(InitialColorPink, TargetColorRed, t);
        Color newBlackColor = Color.Lerp(InitialColorBlack, TargetColorRed, t);

        BunnyMaterialWhite.color = newWhiteColor;
        BunnyMaterialPink.color = newPinkColor;
        BunnyMaterialBlack.color = newBlackColor;

        if (MaxEnemies==EnemiesDestroyed)
        {
            BunnyMaterialWhite.color = InitialColorWhite;
            BunnyMaterialPink.color = InitialColorPink;
            BunnyMaterialBlack.color = InitialColorBlack;
        }

    }
}
