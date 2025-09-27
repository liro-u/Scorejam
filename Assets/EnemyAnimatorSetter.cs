using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class EnemyAnimatorSetter : AnimatorParameterSetter
{
    [SerializeField] private UnityEvent onDeathAnimationStart;
    public void SetIsMoving(bool value)
    {
        SetBoolParameter("isMoving", value);
    }

    public void SetIsDead(bool value)
    {
        Debug.Log(value);
        SetBoolParameter("isDead", value);
        onDeathAnimationStart.Invoke();
    }



}
