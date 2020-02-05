using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSen = 100f;
    public Transform player;

    float xRolation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* mouseSen *Time.deltaTime;

        
        xRolation -= mouseY;
        xRolation = Mathf.Clamp(xRolation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRolation,0f,0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
