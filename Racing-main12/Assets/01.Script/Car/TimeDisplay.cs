using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public Text timerText; // UI Text를 연결하기 위한 변수

    private float currentTime = 0f; // 현재 시간
    private bool isTimerRunning = true; // 타이머가 실행 중인지 여부

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
        // 시간 값을 분과 초로 변환하여 텍스트로 표시합니다.
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
