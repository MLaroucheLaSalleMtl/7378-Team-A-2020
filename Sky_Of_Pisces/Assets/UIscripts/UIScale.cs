using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScale : MonoBehaviour
{
    public void PointerEnter()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public void PointerExit()
    {
        transform.localScale = new Vector2(0.5f, 0.5f);
    }
}
