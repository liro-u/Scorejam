using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private NavMeshObstacle navMeshObstacle;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private GameObject visual;

    [SerializeField] private UnityEvent<string, bool> onOpen;
    [SerializeField] private UnityEvent<string, bool> onClose;

    private bool exist = true;

    public void Open()
    {
        if (!exist) return;

        navMeshObstacle.enabled = false;
        boxCollider.enabled = false;

        onOpen.Invoke("IsOpen", true);
    }

    public void Close()
    {
        navMeshObstacle.enabled = true;
        boxCollider.enabled = true;

        onClose.Invoke("IsOpen", false);
    }

    public void SummonIfExist(bool exist)
    {
        this.exist = exist;

        if (exist)
        {
            Open();
        }
        else
        {
            Close();
        }
        visual.SetActive(exist);
    }
}
