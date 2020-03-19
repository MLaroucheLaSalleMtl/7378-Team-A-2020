using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerQuestForCollection : MonoBehaviour
{
    public Image image;
    public Transform Collection;

    public Text meter;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //To set limition for the pointer on the screen
        float minX = image.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = image.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        //Pointer for eden
        Vector2 position = Camera.main.WorldToScreenPoint(Collection.position + offset);
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        if (Vector3.Dot(Collection.position - transform.position, transform.forward) < 0)
        {
            //Target behind the player
            if (position.x < Screen.width / 2)
            {
                position.x = maxX;

            }
            else
            {
                position.x = minX;

            }
        }

        //Info for eden
        meter.text = ((int)Vector3.Distance(Collection.position, transform.position)).ToString() + "M";
        image.transform.position = position;
    }
}
