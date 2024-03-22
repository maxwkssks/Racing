using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour
{
    public float maxDamage = 100f;
    public float currentDamage = 0f;
    public Color startColor = Color.green;
    public Color middleColor = Color.blue;
    public Color endColor = Color.red;
    public float damagePerSecond = 1f; // 초당 입히는 데미지 양

    private Renderer tireRenderer;
    private float totalDistance = 0f;
    private Vector3 lastPosition;

    private void Start()
    {
        // 초기 색상 설정
        SetColor(startColor);

        // 타이어 렌더러 가져오기
        tireRenderer = GetComponent<Renderer>();

        // 시작 위치 설정
        lastPosition = transform.position;
    }

    private void Update()
    {
        // 플레이어가 이동한 거리 계산
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);
        totalDistance += distanceMoved;

        // 거리에 따른 데미지 계산
        float damageAmount = distanceMoved * damagePerSecond;

        // 타이어에 데미지 입히기
        currentDamage += damageAmount;
        currentDamage = Mathf.Clamp(currentDamage, 0f, maxDamage);
        UpdateColor();

        // 현재 위치를 마지막 위치로 갱신
        lastPosition = transform.position;
    }

    private void UpdateColor()
    {
        float damagePercentage = currentDamage / maxDamage;

        // 색상 보간
        Color lerpedColor = Color.Lerp(startColor, middleColor, damagePercentage);
        lerpedColor = Color.Lerp(lerpedColor, endColor, damagePercentage);

        SetColor(lerpedColor);
    }

    private void SetColor(Color color)
    {
        if (tireRenderer != null)
        {
            tireRenderer.material.color = color;
        }
        else
        {
            Debug.LogWarning("Renderer component not found.");
        }
    }
}