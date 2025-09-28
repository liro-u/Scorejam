using UnityEngine;

public class MonsterAudioController : MonoBehaviour
{
    public AudioClip[] hurtSounds, fireSounds, walkSounds;
    private AudioSource thisAS;
    private void Awake()
    {
        thisAS = GetComponent<AudioSource>();
    }
    public void PlayMonsterAudio(int toggle)
    {
        thisAS.pitch = Random.Range(0.8f, 1.3f);
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
        }

    }

    public void PlayRandomFromGroup(AudioClip[] group)
    {
        thisAS.PlayOneShot(group[Random.Range(0, group.Length)], .7f);
    }
}
