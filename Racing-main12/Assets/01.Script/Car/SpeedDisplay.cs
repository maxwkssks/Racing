using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody rb; // Rigidbody2D 컴포넌트를 연결하기 위한 변수
    public Text speedText; // UI Text를 연결하기 위한 변수

    void Update()
    {
        // Rigidbody2D의 속도를 기반으로 속도를 가져옵니다.
        float speed = rb.velocity.magnitude;

        // 속도 값을 소수점 둘째 자리까지 반올림하여 표시합니다.
        speedText.text = "Speed " + speed.ToString("F2");
    }
}