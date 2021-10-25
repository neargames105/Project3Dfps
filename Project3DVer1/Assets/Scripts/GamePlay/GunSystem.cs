using UnityEngine;
using DG.Tweening;
public class GunSystem : ItemBase
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletHolder;
    private Animator anim;
    public override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
    }
    public void Update()
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
    public override void Start()
    {
        //
        base.Start();
        //set gun in the firstime
        if (transform.parent)
        {
            s_GameCore.Instance.gunSystem = this;
        }
    }
    public void Fire(Vector3 pos , Quaternion rot)
    {
        if (bulletHolder <=0)
        {
            ThrowItem(Camera.main.transform.forward);
            return;
        }
        //instance a bullet 
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.localPosition = pos;
        newBullet.transform.localRotation = rot;
        bulletHolder -= 1;
        //shake camera when shot
        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(.8f, .04f, 10, 90, false, true).SetUpdate(true);
    }
    public override void PickUpItem()
    {
        base.PickUpItem();
        s_GameCore.Instance.gunSystem = this;
        transform.parent = s_GameCore.Instance.itemHolder;
    }
}
