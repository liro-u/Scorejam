using UnityEngine;

public class MusicLooperSeamless : MonoBehaviour
{
    [Header("Music Clips")]
    [SerializeField] private AudioClip introClip;
    [SerializeField] private AudioClip loopClip;

    private AudioSource introSource;
    private AudioSource loopSource;

    private void Awake()
    {
        // Create two audio sources: one for intro, one for loop
        introSource = gameObject.AddComponent<AudioSource>();
        loopSource = gameObject.AddComponent<AudioSource>();

        introSource.playOnAwake = false;
        loopSource.playOnAwake = false;

        introSource.loop = false;
        loopSource.loop = true;
    }

    private void Start()
    {
        PlayIntroThenLoop();
    }

    public void PlayIntroThenLoop()
    {
        if (introClip == null || loopClip == null)
        {
            Debug.LogWarning("Intro or loop clip not assigned for MusicLooperSeamless.");
            return;
        }

        // Play intro immediately
        introSource.clip = introClip;
        introSource.Play();

        // Schedule loop to start when intro ends
        double startTime = AudioSettings.dspTime + introClip.length;
        loopSource.clip = loopClip;
        loopSource.PlayScheduled(startTime);
    }

    public void Stop()
    {
        introSource.Stop();
        loopSource.Stop();
    }
}
