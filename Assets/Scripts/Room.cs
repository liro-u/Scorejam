using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] public bool canGoUp = true;
    [SerializeField] public bool canGoDown = false;
    [SerializeField] public bool canGoLeft = false;
    [SerializeField] public bool canGoRight = false;

    [SerializeField] public int numberEnemy = 1;

    [SerializeField] private Door leftDoor;
    [SerializeField] private Door rightDoor;
    [SerializeField] private Door topDoor;
    [SerializeField] private Door BottomDoor;

    [SerializeField] private EnemyParent EnemyParent;

    [SerializeField] public bool hasFinishRoom = false;

    [SerializeField] private UnityEvent onRoomStart;

    public void Start()
    {
        SummonAllDoor();

        OpenAllDoor();
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
    }

    public void SummonEnemy()
    {
        if (hasFinishRoom) return;
        EnemyParent.SummonRandomEnemies(numberEnemy);
        hasFinishRoom = true;
    }
}
