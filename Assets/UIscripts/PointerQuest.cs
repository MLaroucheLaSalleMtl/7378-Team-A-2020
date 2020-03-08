using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerQuest : MonoBehaviour
{
    public Image image;
    public Transform Eden;
    //public Transform Ghost;

    public Text meter;
    public Vector3 offset;
    
    // Update is called once per frame
    private void Update()
    {
        //To set limition for the pointer on the screen
        float minX = image.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = image.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        //Pointer for eden
        Vector2 position = Camera.main.WorldToScreenPoint(Eden.position+offset);  
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        //Pointer for ghost
        //Vector2 position1 = Camera.main.WorldToScreenPoint(Ghost.position + offset);
        //position1.x = Mathf.Clamp(position1.x, minX, maxX);
        //position1.y = Mathf.Clamp(position1.y, minY, maxY);

        
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
        //if (Vector3.Dot(Ghost.position - transform.position, transform.forward) < 0)
        //{
        //    if (position1.x < Screen.width / 2)
        //    {
        //        position1.x = maxX;
        //    }
        //    else
        //    {
        //        position1.x = minX;
        //    }
        //}
        
        

        //Info for eden
        meter.text = ((int)Vector3.Distance(Eden.position, transform.position)).ToString() + "M";
        image.transform.position = position;

        //Info for ghost
        //meter.text = ((int)Vector3.Distance(Ghost.position, transform.position)).ToString() + "M";
        //image.transform.position = position;
    }
}
