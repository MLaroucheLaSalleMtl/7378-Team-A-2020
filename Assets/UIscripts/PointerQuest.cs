using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerQuest : MonoBehaviour
{
    public Image image;
    public Transform Eden;
    public Text meter;
    public Vector3 offset;
    
    // Update is called once per frame
    void Update()
    {
        //To set limition for the pointer on the screen
        float minX = image.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        float minY = image.GetPixelAdjustedRect().width / 2;
        float maxY = Screen.width - minY;

        Vector2 position = Camera.main.WorldToScreenPoint(Eden.position+offset);
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);
        image.transform.position = position;

        if (Vector3.Dot(Eden.position - transform.position, transform.forward) < 0)
        {
            //Target behind the player
            if(position.x < Screen.width / 2)
            {
                position.x = maxX;
            }
            else
            {
                position.x = minX;
            }
        }
        meter.text = ((int)Vector3.Distance(Eden.position, transform.position)).ToString() + "M";

    }
}
