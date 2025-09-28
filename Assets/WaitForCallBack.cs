using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaitForCallBack : MonoBehaviour
{
    [SerializeField] private float waitFor = 1f;
    [SerializeField] UnityEvent callback;

    public void StartCallbackCoRoutine()
    {
        StartCoroutine(callbackCoroutine());
    }

    private IEnumerator callbackCoroutine()
    {
        yield return new WaitForSeconds(waitFor);
        callback.Invoke();
    }
    
}
