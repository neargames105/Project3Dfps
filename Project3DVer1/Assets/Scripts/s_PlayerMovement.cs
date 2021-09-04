using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private Vector3 direction;
    private float h, v;
    [SerializeField] private float playerSpeed;

    //Camera setting
    [SerializeField] private Camera cam;
    private float mouseX, mouseY;
    private float rotX, rotY;
    [SerializeField] private float MouseSensitive;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        //rb.AddForce(direction.normalized*playerSpeed, ForceMode.Acceleration);
        //
        cam.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotY, 0);
        //time control
        float time = (h != 0 || v != 0) ? 1f : 0.03f;
        Time.timeScale = Mathf.Lerp(Time.timeScale, time, .5f);
    }
    private void FixedUpdate()
    {
        rb.AddForce(direction.normalized * playerSpeed, ForceMode.Acceleration);
    }
    void MyInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        direction = transform.forward * v + transform.right * h;
        //cam
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        rotX -= mouseY * MouseSensitive;
        rotY += mouseX * MouseSensitive;
        
    }
}
