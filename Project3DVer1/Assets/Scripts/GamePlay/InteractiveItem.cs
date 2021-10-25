using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractiveItem : ItemBase
{
    public override void PickUpItem()
    {
        base.PickUpItem();
        s_GameCore.Instance.item = this;
        transform.parent = s_GameCore.Instance.itemHolder;
    }
}
