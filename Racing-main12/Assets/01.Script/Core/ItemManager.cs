using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] itemList; // 아이템 리스트
    public float spawnRadius;
    public GameObject[] WayPoints;

    // Start 함수에서 2초마다 호출하여 아이템 생성
    private void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    // 일정 시간 간격으로 아이템을 생성하는 코루틴 함수
    IEnumerator ItemSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // 2초마다 실행

            if (WayPoints.Length > 0)
            {
                GameObject randomWaypoint = WayPoints[UnityEngine.Random.Range(0, WayPoints.Length)];
                Vector3 waypointPosition = randomWaypoint.transform.position;
                SpawnItemPosition(waypointPosition);
            }
            else
            {
                Debug.LogError("Waypoint를 찾을 수 없습니다.");
            }
        }
    }

    // Waypoint를 중심점으로 하여 범위 내에서 아이템을 생성하는 함수
    public void SpawnItemPosition(Vector3 waypointPosition)
    {
        // 해당 Waypoint에 이미 아이템이 있는지 확인
        Collider[] colliders = Physics.OverlapSphere(waypointPosition, 0.1f); // 작은 범위 내에 오브젝트가 있는지 확인
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Item")) // 아이템 태그가 있는 오브젝트인지 확인
            {
                Debug.Log("해당 Waypoint에 이미 아이템이 있습니다.");
                return;
            }
        }


        // Waypoint 위치를 중심으로 무작위로 위치를 선택
        Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * spawnRadius;
        Vector3 randomOffset = new Vector3(randomCircle.x, 0, randomCircle.y);
        Vector3 spawnPosition = waypointPosition + randomOffset;

        // 아이템을 무작위로 선택하여 생성
        if (itemList.Length > 0)
        {
            GameObject selectedItem = itemList[UnityEngine.Random.Range(0, itemList.Length)];
            Instantiate(selectedItem, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("아이템 리스트가 비어 있습니다.");
        }
    }
}
