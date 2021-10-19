using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpControl : s_GameCore
{
    public Transform Player;
    public Transform GunHold;
    private Rigidbody rb;
    public float zForce;
    private float startTime;
    private float journeyLength;
    private bool callGun;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    private void Update()
    {
        Vector3 distanceToPlayer = Player.position - transform.position;
        if (distanceToPlayer.magnitude <= 20f && Input.GetKeyDown(KeyCode.E))
        {
            PickUpWeapon();
            StopCoroutine(ActionE(.6f));
            StartCoroutine(ActionE(.6f));

        }
        if (Input.GetMouseButtonDown(1))
        {
            ThrowWeapon();
            StopCoroutine(ActionE(.06f));
            StartCoroutine(ActionE(.06f));
        }
        if (callGun)
        {
            var disCovered = (Time.time - startTime) * zForce;
            var fractionOfJourney = disCovered / journeyLength;
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, fractionOfJourney);
        }
    }
    public void ThrowWeapon()
    {
        callGun = false;
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(cam.transform.forward * zForce, ForceMode.Impulse);
        var random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random));
    }
    public void PickUpWeapon()
    {
        callGun = true;
        //
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, Player.position);
        //
        transform.SetParent(GunHold);
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        rb.isKinematic = true;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().Dead();
        }
    }

}
