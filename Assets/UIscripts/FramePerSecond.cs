using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePerSecond : MonoBehaviour
{
    Rect fpsRect;
    GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        fpsRect = new Rect(100, 100, 400, 100);
        style = new GUIStyle();
        style.fontSize = 40;
       
        
    }
    
    private void OnGUI()
    {
        float fps = 1 / Time.deltaTime;
        GUI.Label(fpsRect, "FPS :" + string.Format("{0:0}" ,fps),style);
    }
}
