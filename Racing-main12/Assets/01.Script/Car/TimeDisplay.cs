using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public Text timerText; // UI Text�� �����ϱ� ���� ����

    private float currentTime = 0f; // ���� �ð�
    private bool isTimerRunning = true; // Ÿ�̸Ӱ� ���� ������ ����

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        // �ð� ���� �а� �ʷ� ��ȯ�Ͽ� �ؽ�Ʈ�� ǥ���մϴ�.
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
