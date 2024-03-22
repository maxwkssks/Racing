using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ShopManager : MonoBehaviour
{
    public int DesertWhellCoin;
    public int MountainWhellCoin;
    public int DownTownWhellCoin;
    public TextMeshProUGUI DesertText;
    public TextMeshProUGUI MountainText;
    public TextMeshProUGUI DownTownText;
    public TextMeshProUGUI Coin;
    

    public Canvas ShopCanvas;

    public void ShopExit()
    {
        if (!GameInstance.instance.isclear)
        {
            Time.timeScale = 1f;
            ShopCanvas.gameObject.SetActive(false);
        } 
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene($"Stage{GameInstance.instance.Stage+1}");
        }
    }
    public void Shop()
    {
         
        DesertText.text = $"{DesertWhellCoin}";
        MountainText.text = $"{MountainWhellCoin}";
        DownTownText.text = $"{DownTownWhellCoin}";
        ShopCanvas.gameObject.SetActive(true);
        
    }

    public void Desert()
    {
        if(GameInstance.instance.Coin >= DesertWhellCoin && !GameInstance.instance.isDesertWheel)
        {
            GameInstance.instance.isDesertWheel = true;
        }
    }
    public void Mountain()
    {
        if (GameInstance.instance.Coin >= MountainWhellCoin && !GameInstance.instance.isMountainWheel)
        {
            GameInstance.instance.isMountainWheel = true;
        }
    }
    public void DownTown()
    {
        if (GameInstance.instance.Coin >= DownTownWhellCoin && !GameInstance.instance.isDownTownWheel)
        {
            GameInstance.instance.isDownTownWheel = true;
        }
    }

    public void Update()
    {
        Coin.text = $"Coin : {GameInstance.instance.Coin}";
    }

}
