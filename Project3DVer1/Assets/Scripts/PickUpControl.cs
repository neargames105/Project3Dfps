using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpControl : MonoBehaviour
{
    private Camera cam;
    public Transform GunHold;
    private Rigidbody rb;
    public float speed;
    //
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    private void Start()
    {
        rb.isKinematic = true;
        rb.useGravity = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && transform.parent == null)
        {
            PickUpWeapon();
        }
        if (Input.GetMouseButtonDown(1) && transform.parent != null)
        {
            ThrowWeapon();
        }
    }
    public void ThrowWeapon()
    {
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(cam.transform.forward * speed, ForceMode.Impulse);
        var random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random)*10f);
    }
    public void PickUpWeapon()
    {
        GunHold = cam.transform.Find("GunHolder");
        transform.SetParent(GunHold);
        rb.isKinematic = true;
        //
        transform.DOLocalMove(Vector3.zero, .25f).SetEase(Ease.OutBack).SetUpdate(true);
        transform.DOLocalRotate(Vector3.zero, .25f).SetUpdate(true);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().Dead();
            Destroy(gameObject);
        }
    }

}
