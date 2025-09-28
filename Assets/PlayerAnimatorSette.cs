using UnityEngine;

public class PlayerAnimatorSetter : AnimatorParameterSetter
{
    public void SetIsMoving(bool value)
    {
        SetBoolParameter("isMoving", value);
    }

    public void SetIsDead(bool value)
    {
        SetBoolParameter("isDead", value);
    }

    public void SetIsRolling(bool value)
    {
        SetBoolParameter("isRolling", value);
    }
}
