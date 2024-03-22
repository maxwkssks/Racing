using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI RacingTimeText;
    public TextMeshProUGUI CoinText;
    
    
    // Update is called once per frame
    void Update()
    {
        RacingTimeUpdate();
        CoinUpdate();
    }

    public void RacingTimeUpdate()
    {
        RacingTimeText.text = $"RacingTime : {GameInstance.instance.RacingTime:.##}";
    }

    public  void CoinUpdate()
    {
        CoinText.text = $"Coin : {GameInstance.instance.Coin}";
    }
}
