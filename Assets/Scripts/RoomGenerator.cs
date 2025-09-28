using NavMeshPlus.Components;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private NavMeshSurface navSurf;
    public GameObject roomPrefab;
    public int numberOfRooms = 10;

    public float roomWidth = 10f;
    public float roomHeight = 10f;

    public Transform startTransform;

    private Dictionary<Vector2Int, Room> roomGrid = new Dictionary<Vector2Int, Room>();

    private void Start()
    {
        GenerateRooms();

        if (navSurf != null)
        {
            navSurf.BuildNavMesh();
        }
    }

    void GenerateRooms()
    {
        roomGrid.Clear();

        List<Vector2Int> frontier = new List<Vector2Int>();
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

        Vector2Int startPos = Vector2Int.zero;
        frontier.Add(startPos);

        Vector3 startWorldPos = new Vector3(startTransform.position.x + roomWidth / 6, startTransform.position.y + roomHeight / 2, startTransform.position.z);

        bool firstRoom = true;

        // Base enemy count starts at 2 for the first room
        Dictionary<Vector2Int, int> enemyCounts = new Dictionary<Vector2Int, int>();
        enemyCounts[startPos] = 1;

        while (roomGrid.Count < numberOfRooms && frontier.Count > 0)
        {
            Vector2Int pos = ChooseFrontierCell(frontier, startPos);
            frontier.Remove(pos);

            if (visited.Contains(pos)) continue;
            visited.Add(pos);

            Vector3 worldPos = startWorldPos + new Vector3(pos.x * roomWidth, pos.y * roomHeight, 0);

            GameObject roomObj = Instantiate(roomPrefab, worldPos, Quaternion.identity, transform);
            Room roomComp = roomObj.GetComponent<Room>();

            if (firstRoom)
            {
                roomComp.hasFinishRoom = true;
                roomComp.FocusCamera();
                firstRoom = false;
            }

            // Decide number of enemies
            int baseEnemyCount = enemyCounts[pos];
            roomComp.numberEnemy = Mathf.Min(Mathf.Max(1, ChooseEnemyCount(baseEnemyCount)), 7);

            roomGrid[pos] = roomComp;

            List<Vector2Int> neighbors = new List<Vector2Int>()
            {
                pos + Vector2Int.up,
                pos + Vector2Int.down,
                pos + Vector2Int.left,
                pos + Vector2Int.right
            };

            Shuffle(neighbors);

            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor) && !frontier.Contains(neighbor))
                {
                    frontier.Add(neighbor);

                    // Decide base enemy count for neighbor
                    int newBase = baseEnemyCount;
                    if (Random.value < 0.9f) newBase += 1; // 75% chance to go up by 1

                    enemyCounts[neighbor] = newBase;
                }
            }
        }

        // Set door directions
        foreach (var kvp in roomGrid)
        {
            Vector2Int pos = kvp.Key;
            Room room = kvp.Value;

            room.canGoUp = roomGrid.ContainsKey(pos + Vector2Int.up);
            room.canGoDown = roomGrid.ContainsKey(pos + Vector2Int.down);
            room.canGoLeft = roomGrid.ContainsKey(pos + Vector2Int.left);
            room.canGoRight = roomGrid.ContainsKey(pos + Vector2Int.right);

            room.SummonAllDoor();
        }
    }

    int ChooseEnemyCount(int baseEnemyCount)
    {
        int[] choices = new int[] { baseEnemyCount - 1, baseEnemyCount, baseEnemyCount + 1 };
        int choice = choices[Random.Range(0, choices.Length)];
        return Mathf.Max(1, choice); // Ensure at least 1 enemy
    }

    Vector2Int ChooseFrontierCell(List<Vector2Int> frontier, Vector2Int startPos)
    {
        List<float> weights = new List<float>();
        float totalWeight = 0f;

        foreach (var cell in frontier)
        {
            float distance = Vector2Int.Distance(cell, startPos);
            float weight = distance + 1f; // More distant cells have more weight
            weights.Add(weight);
            totalWeight += weight;
        }

        float rnd = Random.Range(0f, totalWeight);
        for (int i = 0; i < frontier.Count; i++)
        {
            rnd -= weights[i];
            if (rnd <= 0f)
            {
                return frontier[i];
            }
        }

        return frontier[0];
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            (list[rnd], list[i]) = (list[i], list[rnd]);
        }
    }
}
