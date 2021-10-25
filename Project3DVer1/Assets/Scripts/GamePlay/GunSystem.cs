using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class GunSystem : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletHolder;
    //gun
    Rigidbody rb;
    [SerializeField] private float throwForced;
    private Animator anim;
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.parent)
        {
            anim.SetBool("isRecoil" , true);
        }
        else if (Input.GetMouseButtonUp(0) && transform.parent)
        {
            anim.SetBool("isRecoil", false);
        }
    }

    public void Start()
    {
        //
        if (transform.parent)
        {
            s_GameCore.Instance.gunSystem = this;
        }
    }
    public void Fire(Vector3 pos , Quaternion rot)
    {
        if (bulletHolder <=0)
        {
            ThrowWeapon(Camera.main.transform.forward);
            return;
        }
        //
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.localPosition = pos;
        newBullet.transform.localRotation = rot;
        bulletHolder -= 1;
        //shake camera when shot
        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(.8f, .04f, 10, 90, false, true).SetUpdate(true);
    }
    public void ThrowWeapon(Vector3 direction)
    {
        //
        s_GameCore.Instance.gunSystem = null;
        //
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(direction * throwForced, ForceMode.Impulse);
        var random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10f);
    }
    public void PickUpWeapon()
    {
        Debug.Log("pick");
        //
        s_GameCore.Instance.gunSystem = this;
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
