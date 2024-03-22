using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cheat();
    }

    public void Cheat()
    {
        if (!GameInstance.instance.isStop)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {

            }
            if (Input.GetKeyDown(KeyCode.F2))
            {

            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                switch (GameInstance.instance.Stage)
                {
                    case 1:
                        SceneManager.LoadScene("Stage1");
                        break;
                    case 2:
                        SceneManager.LoadScene("Stage2");
                        break;
                    case 3:
                        SceneManager.LoadScene("Stage3");
                        break;
                    default:
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                switch (GameInstance.instance.Stage)
                {
                    case 1:
                        SceneManager.LoadScene("Stage2");
                        break;
                    case 2:
                        SceneManager.LoadScene("Stage3");
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (GameInstance.instance.isStop)
            {
                Time.timeScale = 1f;
                GameInstance.instance.isStop = false;
            }
            else
            {
                Time.timeScale = 0f;
                GameInstance.instance.isStop = true;
            }
        }

    }

    internal void lose()
    {
        throw new NotImplementedException();
    }
}
