using UnityEngine;

public class ProjectileAudioManager : MonoBehaviour
{
    public AudioClip projectilSound;
    private AudioSource thisAS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        thisAS = GetComponent<AudioSource>();
        thisAS.clip = projectilSound;
        thisAS.pitch = Random.Range(.8f, 1.3f);
        thisAS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
