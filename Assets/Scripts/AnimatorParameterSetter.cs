using UnityEngine;

public class AnimatorParameterSetter : MonoBehaviour
{
    [SerializeField] protected Animator animator;

    public void SetFloatParameter(string key, float value)
    {
        animator.SetFloat(key , value);
    }

    public void SetIntParameter(string key, int value)
    {
        animator.SetInteger(key, value);
    }

    public void SetBoolParameter(string key, bool value)
    {
        animator.SetBool(key, value);
    }
}
