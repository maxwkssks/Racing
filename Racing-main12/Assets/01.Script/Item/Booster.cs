using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : BaseItme
{
    public int Speed;
    public override void Pick()
    {
        StartCoroutine(Player.GetComponent<PlayerCar>().Booster(Speed *1000));
        base.Pick();
    }
}
