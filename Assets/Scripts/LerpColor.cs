using UnityEngine;

public class LerpColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float duration = 0.5f; // time to go to red or back to white

    private void Reset()
    {
        // Auto-assign if not set
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayFlash()
    {
        StopAllCoroutines();
        StartCoroutine(LerpToRedAndBack());
    }

    private System.Collections.IEnumerator LerpToRedAndBack()
    {
        Color start = Color.white;
        Color target = Color.red;

        // White → Red
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            spriteRenderer.color = Color.Lerp(start, target, t);
            yield return null;
        }

        // Red → White
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            spriteRenderer.color = Color.Lerp(target, start, t);
            yield return null;
        }

        spriteRenderer.color = start; // Ensure fully reset
    }
}
