using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public float backgroundMusicVolume = 0.5f;
    private AudioSource musicAudioSource;

    void Start()
    {
        // Create an AudioSource component for background music
        musicAudioSource = gameObject.AddComponent<AudioSource>();
        musicAudioSource.loop = true; // Loop background music
        musicAudioSource.clip = backgroundMusic;

        musicAudioSource.volume = backgroundMusicVolume;

        // Play background music
        musicAudioSource.Play();
    }

}

