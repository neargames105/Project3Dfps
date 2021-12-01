using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlane : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce , 0);
        }
    }
}
