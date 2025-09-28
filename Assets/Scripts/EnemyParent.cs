using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyParent : MonoBehaviour
{
    [SerializeField] private UnityEvent onAllEnemyKilled;

    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private Transform enemyPosList;

    private void OnTransformChildrenChanged()
    {
        if (transform.childCount == 0)
        {
            onAllEnemyKilled.Invoke();
        }
    }

    public void SummonRandomEnemies(int enemyNumber)
    {
        // Get all available spawn positions
        List<Transform> availablePositions = new List<Transform>();
        foreach (Transform child in enemyPosList)
        {
            availablePositions.Add(child);
        }

        // Clamp enemyNumber so we don't request more than available positions
        enemyNumber = Mathf.Min(enemyNumber, availablePositions.Count);

        for (int i = 0; i < enemyNumber; i++)
        {
            // Pick random position
            int randIndex = Random.Range(0, availablePositions.Count);
            Transform pos = availablePositions[randIndex];

            // Pick random enemy prefab
            int prefabIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject prefab = enemyPrefabs[prefabIndex];

            // Spawn
            GameObject enemy = Instantiate(prefab, pos.position, pos.rotation, transform);

            enemy.GetComponent<TargetMovementController>().target = Player.Instance.transform;

            // Remove position so it can't be reused
            availablePositions.RemoveAt(randIndex);
        }
    }
}
