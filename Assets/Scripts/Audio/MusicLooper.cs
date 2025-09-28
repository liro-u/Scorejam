using UnityEngine;

public class MusicLooperSeamless : MonoBehaviour
{
    [Header("Music Clips")]
    [SerializeField] private AudioClip introClip;
    [SerializeField] private AudioClip loopClip;
    [SerializeField]private AudioSource[] _audioSources;

    public double musicDuration;
    public double goalTime;
    public int audioToggle;
    public bool introPlayed = false;
    public AudioClip currentClip;

    private void Awake()
    {
        currentClip = introClip;
        goalTime = AudioSettings.dspTime + 0.5;
    }

    private void Update()
    {
        if(AudioSettings.dspTime > goalTime - 1)
        {
            PlayScheduledClip();
        }
    }

    private void PlayScheduledClip()
    {
        if (introPlayed && currentClip != loopClip)
        {
            currentClip = loopClip;
        }
        _audioSources[audioToggle].clip = currentClip;
        _audioSources[audioToggle].PlayScheduled(goalTime);
        musicDuration = CalcMusicDuration(currentClip);
        goalTime += musicDuration;
        audioToggle = 1 - audioToggle;
        introPlayed = true;
    }

    private double CalcMusicDuration(AudioClip audio)
    {
        return (double)currentClip.samples / currentClip.frequency;
    }

}
