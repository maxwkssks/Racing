using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody rb; // Rigidbody2D ������Ʈ�� �����ϱ� ���� ����
    public Text speedText; // UI Text�� �����ϱ� ���� ����

    void Update()
    {
        // Rigidbody2D�� �ӵ��� ������� �ӵ��� �����ɴϴ�.
        float speed = rb.velocity.magnitude;

        // �ӵ� ���� �Ҽ��� ��° �ڸ����� �ݿø��Ͽ� ǥ���մϴ�.
        speedText.text = "Speed " + speed.ToString("F2");
    }
}