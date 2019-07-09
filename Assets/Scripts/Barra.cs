using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour {
    private float rotAngle = 0;
    private Vector2 pivotPoint;
    void OnGUI()
    {
        Color color1 = Color.green;
        Color color2 = Color.red;
        Texture2D a = new Texture2D(2, 1);
        a.SetPixel(1, 1, color1);
        a.SetPixel(10, 1, color2);
        a.filterMode = FilterMode.Bilinear;
        a.wrapMode = TextureWrapMode.Clamp;
        a.Apply();
        GUIUtility.RotateAroundPivot(-GameObject.Find("GameObject").GetComponent<Gun>().rotacio, new Vector2(Screen.width / 2, Screen.height));
        GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height - 4, 128, 8), a);
        


    }
}
