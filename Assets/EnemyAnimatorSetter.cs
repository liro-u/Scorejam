using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class EnemyAnimatorSetter : AnimatorParameterSetter
{
    public void SetIsMoving(bool value)
    {
        SetBoolParameter("isMoving", value);
    }
    
}
