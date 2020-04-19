using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    // Update is called once per frame
    public int lastPressed = 0;
    public GameObject Inventroy;
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.I))
    //    {
    //        Inventroy.SetActive(true);
    //         lastPressed++;
    //        if (lastPressed > 1)
    //        {
    //            Inventroy.SetActive(false);
    //            lastPressed = 0;
    //        }
    //    }

    //}

    public void onOpenInventory(InputAction.CallbackContext context)
    {
        Inventroy.SetActive(true);
        lastPressed++;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (lastPressed > 1)
        {
            Inventroy.SetActive(false);
            lastPressed = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
