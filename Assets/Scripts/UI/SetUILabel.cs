using System.Collections;
using TMPro;
using UnityEngine;

public class SetUILabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private string prefix = "";
    [SerializeField] private string sufix = "";
    [SerializeField] private float fadeDuration = 1f; // durée du fade in/out
    [SerializeField] private float visibleDuration = 1f; // temps visible à opacité max

    public void SetLabel(float value)
    {
        label.text = prefix + value.ToString() + sufix;
    }

    public void SetLabelBonus(int value)
    {
        string suffix = "";
        switch (value)
        {
            case (int)BonusType.AttackBoost:
                suffix = "Attack Damage Boost";
                break;
            case (int)BonusType.AttackSpeedBoost:
                suffix = "Attack Speed Boost";
                break;
            case (int)BonusType.Heal:
                suffix = "1 life";
                break;
            case (int)BonusType.Points:
                suffix = "10 000 Points";
                break;
            case (int)BonusType.Shotgun:
                suffix = "Shotgun";
                break;
            case (int)BonusType.SpeedBoost:
                suffix = "Speed Boost";
                break;
        }

        label.text = "Bonus " + value + "\n" + suffix;

        // Démarre le fade
        StopAllCoroutines();
        StartCoroutine(BonusLabelCoroutine());
    }

    public IEnumerator BonusLabelCoroutine()
    {
        yield return new WaitForSeconds(2);

        Color baseColor = label.color;

        // --- Fade In ---
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            label.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
            yield return null;
        }

        // --- Stay Visible ---
        yield return new WaitForSeconds(visibleDuration);

        // --- Fade Out ---
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            label.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
            yield return null;
        }

        // Cache complètement à la fin
        label.color = new Color(baseColor.r, baseColor.g, baseColor.b, 0f);
    }
}
