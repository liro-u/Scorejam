using UnityEngine;

public class PlayerAnimatorSetter : AnimatorParameterSetter
{
    public void SetIsMoving(bool value)
    {
        SetBoolParameter("isMoving", value);
    }
}
