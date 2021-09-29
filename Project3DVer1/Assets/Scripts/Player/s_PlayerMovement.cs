using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class s_PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    private float h, v;
    [SerializeField] private float playerSpeed;
    //Camera setting
    [SerializeField] private Camera cam;
    private float mouseX, mouseY;
    private float rotX, rotY;
    [SerializeField] private float MouseSensitive;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        MyInput();
        TimeControl();
    }
    private void FixedUpdate()
    {
        rb.AddForce(direction.normalized * playerSpeed, ForceMode.Acceleration);
    }
    private void MyInput()
    {
        //input
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        direction = transform.forward * v + transform.right * h;
        //cam
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        rotX -= mouseY * MouseSensitive;
        rotY += mouseX * MouseSensitive;
        //player looking
        cam.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
    private void TimeControl()
    {
        //time control
        float time = (h != 0 || v != 0) ? 1f : 0.03f;
        Time.timeScale = Mathf.Lerp(Time.timeScale, time, .5f);
    }
}
