using UnityEngine;

public class GameObjectRemover : MonoBehaviour
{
    public void Remove(GameObject target)
    {
        if (target != null)
        {
            Debug.Log(target);
            Destroy(target);
        }
    }
}
