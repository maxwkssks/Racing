using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class FinishLine : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log(tag);

        if (collider.gameObject.CompareTag("Player"))
        {
            if (GameInstance.instance.Stage != 3 )
            {
                GameInstance.instance.StageTime[GameInstance.instance.Stage -1] = GameInstance.instance.RacingTime;
                ShopManager shopManager = GetComponent<ShopManager>();
                shopManager.Shop();
                SceneManager.LoadScene($"Stage{GameInstance.instance.Stage + 1}");
            }
        }
        else
        {
            GameInstance.instance.RacingTime = 0f;
            SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");
        }
    }
}
