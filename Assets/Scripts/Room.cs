using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private bool canGoUp = true;
    [SerializeField] private bool canGoDown = false;
    [SerializeField] private bool canGoLeft = false;
    [SerializeField] private bool canGoRight = false;

    [SerializeField] private Door leftDoor;
    [SerializeField] private Door rightDoor;
    [SerializeField] private Door topDoor;
    [SerializeField] private Door BottomDoor;

    [SerializeField] private GameObject EnemyParent;

    [SerializeField] private bool hasFinishRoom = false;

    [SerializeField] private UnityEvent onRoomStart;

    public void Start()
    {
        SummonAllDoor();

        OpenAllDoor();

        EnemyParent.SetActive(false);
    }

    public void SummonAllDoor()
    {
        leftDoor.SummonIfExist(canGoLeft);
        rightDoor.SummonIfExist(canGoRight);
        BottomDoor.SummonIfExist(canGoDown);
        topDoor.SummonIfExist(canGoUp);
    }

    public void OpenAllDoor()
    {
        leftDoor.Open();
        rightDoor.Open();
        BottomDoor.Open();
        topDoor.Open();
    }

    public void CloseAllDoor()
    {
        leftDoor.Close();
        rightDoor.Close();
        BottomDoor.Close();
        topDoor.Close();
    }

    public void StartRoom()
    {
        if (hasFinishRoom) return;
        CloseAllDoor();
        onRoomStart.Invoke();
    }

    public void FinishRoom()
    {
        
        OpenAllDoor();
        hasFinishRoom = true;
    }

    public void SummonEnemy()
    {
        EnemyParent.SetActive(true);
    }
}
