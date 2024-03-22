using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] itemList; // ������ ����Ʈ
    public float spawnRadius;
    public GameObject[] WayPoints;

    // Start �Լ����� 2�ʸ��� ȣ���Ͽ� ������ ����
    private void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    // ���� �ð� �������� �������� �����ϴ� �ڷ�ƾ �Լ�
    IEnumerator ItemSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // 2�ʸ��� ����

            if (WayPoints.Length > 0)
            {
                GameObject randomWaypoint = WayPoints[UnityEngine.Random.Range(0, WayPoints.Length)];
                Vector3 waypointPosition = randomWaypoint.transform.position;
                SpawnItemPosition(waypointPosition);
            }
            else
            {
                Debug.LogError("Waypoint�� ã�� �� �����ϴ�.");
            }
        }
    }

    // Waypoint�� �߽������� �Ͽ� ���� ������ �������� �����ϴ� �Լ�
    public void SpawnItemPosition(Vector3 waypointPosition)
    {
        // �ش� Waypoint�� �̹� �������� �ִ��� Ȯ��
        Collider[] colliders = Physics.OverlapSphere(waypointPosition, 0.1f); // ���� ���� ���� ������Ʈ�� �ִ��� Ȯ��
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Item")) // ������ �±װ� �ִ� ������Ʈ���� Ȯ��
            {
                Debug.Log("�ش� Waypoint�� �̹� �������� �ֽ��ϴ�.");
                return;
            }
        }


        // Waypoint ��ġ�� �߽����� �������� ��ġ�� ����
        Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * spawnRadius;
        Vector3 randomOffset = new Vector3(randomCircle.x, 0, randomCircle.y);
        Vector3 spawnPosition = waypointPosition + randomOffset;

        // �������� �������� �����Ͽ� ����
        if (itemList.Length > 0)
        {
            GameObject selectedItem = itemList[UnityEngine.Random.Range(0, itemList.Length)];
            Instantiate(selectedItem, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("������ ����Ʈ�� ��� �ֽ��ϴ�.");
        }
    }
}
