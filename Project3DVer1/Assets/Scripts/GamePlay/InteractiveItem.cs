using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractiveItem : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float throwForced;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.isKinematic = true;
    }
    public void ThrowItem(Vector3 direction)
    {
        //
        s_GameCore.Instance.gunSystem = null;
        s_GameCore.Instance.item = null;
        //
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(direction * throwForced, ForceMode.Impulse);
        var random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10f);
    }
    public void PickUpItem()
    {
        Debug.Log("pick");
        //
        s_GameCore.Instance.item = this;
        //
        transform.parent = s_GameCore.Instance.itemHolder;
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
