using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineShop : BaseItme
{
    public override void Pick()
    {
        Time.timeScale = 0f;
        ShopManager shopManager = FindObjectOfType<ShopManager>();
        shopManager.Shop();
        base.Pick();
    }
}
