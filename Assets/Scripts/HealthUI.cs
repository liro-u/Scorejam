using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject hp0;
    [SerializeField] private GameObject hp1;
    [SerializeField] private GameObject hp2;
    [SerializeField] private GameObject hp3;

    private GameObject[] hpStates;

    private void Awake()
    {
        // Put them into an array for easier indexing
        hpStates = new GameObject[] { hp0, hp1, hp2, hp3 };
        SetLife(3);
    }
    public void SetLife(float currentHealth)
    {
        int index = Mathf.Clamp(Mathf.RoundToInt(currentHealth), 0, hpStates.Length - 1);

        for (int i = 0; i < hpStates.Length; i++)
        {
            if (hpStates[i] != null)
                hpStates[i].SetActive(i == index);
        }
    }
}
