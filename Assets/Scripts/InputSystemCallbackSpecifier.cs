using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputSystemCallbackSpecifier : MonoBehaviour
{
    [Header("Input Action Callbacks")]
    [SerializeField] private UnityEvent onStarted;
    [SerializeField] private UnityEvent onPerformed;
    [SerializeField] private UnityEvent onCanceled;

    public void OnInputAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            onStarted?.Invoke();
            GetComponent<PlayerAudioControl>().PlayPlayerSound(1);
        }
        else if (context.performed)
            onPerformed?.Invoke();
        else if (context.canceled)
            onCanceled?.Invoke();
    }
}
