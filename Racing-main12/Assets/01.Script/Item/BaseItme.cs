using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseItme : MonoBehaviour
{
    [HideInInspector] 
    public GameObject Player;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("됨");
            Player = collision.gameObject;
            Pick();
        }
        else
        {
            Debug.Log("누?구");
        }
    }

    public virtual void Pick()
    {
        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}
