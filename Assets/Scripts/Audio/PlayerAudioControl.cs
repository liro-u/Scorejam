using UnityEngine;

public class PlayerAudioControl : MonoBehaviour
{
    /// <summary>
    /// Controller for all player related sounds.
    /// If more libraries are needed, just add to the AudioClip array.
    /// The toggles are as follows :
    ///  0 -> Hurt
    ///  1 -> Fire
    ///  2 -> Walk
    ///  3 -> Victory
    /// </summary>
    [SerializeField]
    public AudioClip[] hurtSounds, fireSounds, victorySounds, walkSounds;
    public AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlayPlayerSound(int toggle)
    {
        audioSrc.pitch = Random.Range(0.8f,1.3f);
        switch (toggle) 
        {
            case 0:
                PlayRandomFromGroup(hurtSounds);
                break;

            case 1:
                PlayRandomFromGroup(fireSounds);
                break;

            case 2:
                PlayRandomFromGroup(walkSounds);
                break;

            case 3:
                PlayRandomFromGroup(victorySounds);
                break;
        }
        
    }

    public void PlayRandomFromGroup(AudioClip[] group)
    {
        audioSrc.PlayOneShot(group[Random.Range(0, group.Length)], .5f);
    }
}
