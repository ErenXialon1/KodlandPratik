using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float mouseSense = 1f;  
    private float rotateX;
    private float rotateY;

    
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
        rotateX += Input.GetAxis("Mouse X") * mouseSense;
        rotateY -= Input.GetAxis("Mouse Y") * mouseSense;
        rotateY = Mathf.Clamp(rotateY, -90f, 90f);
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(rotateY, rotateX, 0);
    }
}
