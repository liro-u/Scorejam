using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.InputSystem;


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
    [SerializeField] private Transform CameraTarget;

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
        hasFinishRoom = true;
        StartCoroutine(StartRoomCoroutine());
    }

    private IEnumerator StartRoomCoroutine()
    {
        CloseAllDoor();

        yield return new WaitForSeconds(2);


        BonusManager.Instance.ChoseRandomBonus();
        Player.Instance.GetComponent<PlayerAnimatorSetter>().SetIsRolling(true);
        Player.Instance.GetComponent<PlayerInput>().enabled = false;

        yield return new WaitForSeconds(2);

        Player.Instance.GetComponent<PlayerAnimatorSetter>().SetIsRolling(false);
        Player.Instance.GetComponent<PlayerInput>().enabled = true;

        Player.Instance.GetComponent<HealthSystem>().ProtectForXTime(5);

        onRoomStart.Invoke();
    }

    public void FinishRoom()
    {
        OpenAllDoor();
        ScoreManager.Instance.AddRoomCompleted();
    }

    public void SummonEnemy()
    {
        EnemyParent.SummonRandomEnemies(numberEnemy);
    }

    public void FocusCamera()
    {
        CameraFollow.Instance.SetTarget(CameraTarget);
    }

}
