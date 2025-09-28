using UnityEngine;
using UnityEngine.Events;

public class EnemyParent : MonoBehaviour
{
    [SerializeField] private UnityEvent onAllEnemyKilled;
    void OnTransformChildrenChanged()
    {
        if (transform.childCount == 0)
        {
            onAllEnemyKilled.Invoke();
        }
    }

}
