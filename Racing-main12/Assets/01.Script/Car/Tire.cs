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
    public float damagePerSecond = 1f; // �ʴ� ������ ������ ��

    private Renderer tireRenderer;
    private float totalDistance = 0f;
    private Vector3 lastPosition;

    private void Start()
    {
        // �ʱ� ���� ����
        SetColor(startColor);

        // Ÿ�̾� ������ ��������
        tireRenderer = GetComponent<Renderer>();

        // ���� ��ġ ����
        lastPosition = transform.position;
    }

    private void Update()
    {
        // �÷��̾ �̵��� �Ÿ� ���
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);
        totalDistance += distanceMoved;

        // �Ÿ��� ���� ������ ���
        float damageAmount = distanceMoved * damagePerSecond;

        // Ÿ�̾ ������ ������
        currentDamage += damageAmount;
        currentDamage = Mathf.Clamp(currentDamage, 0f, maxDamage);
        UpdateColor();

        // ���� ��ġ�� ������ ��ġ�� ����
        lastPosition = transform.position;
    }

    private void UpdateColor()
    {
        float damagePercentage = currentDamage / maxDamage;

        // ���� ����
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