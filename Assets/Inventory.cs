using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Update is called once per frame
    public int lastPressed = 0;
    public GameObject Inventroy;
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            Inventroy.SetActive(true);
             lastPressed++;
            if (lastPressed > 1)
            {
                Inventroy.SetActive(false);
                lastPressed = 0;
            }
        }

    }
}
