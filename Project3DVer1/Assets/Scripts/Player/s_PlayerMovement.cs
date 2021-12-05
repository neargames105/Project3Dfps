using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class s_PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;
    private Vector3 direction;
    [SerializeField] private float playerSpeed;
    //Camera setting
    private float mouseX, mouseY;
    private float rotX, rotY;
    [SerializeField] private float MouseSensitive;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    private void Start()
    {
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        MyInput();
        if (rb.velocity.y <= 0.1f)
        {
            s_GameCore.Instance.TimeControl();
        }
        //s_GameCore.Instance.TimeControl();
    }
    private void FixedUpdate()
    {
        rb.AddForce(direction.normalized * playerSpeed, ForceMode.Acceleration);
    }
    private void MyInput()
    {
        //input
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        direction = transform.forward * v + transform.right * h;
        //cam
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        rotX -= mouseY * MouseSensitive * Time.unscaledDeltaTime;
        rotY += mouseX * MouseSensitive * Time.unscaledDeltaTime;
        //player looking
        cam.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
