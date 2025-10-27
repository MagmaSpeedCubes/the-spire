using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(AudioSource))]
public class SoundHandler : MonoBehaviour
{
    private AudioSource audioSource;
    private static SoundHandler instance;
    public List<SoundEffect> soundEffects;
    public List<SoundEffect> originalSoundtrack;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning("Multiple SoundHandlers detected. Destroying duplicate");
            Destroy(this);
        }
    }

    public void playSoundInstance(string soundName, float volume)
    {
        // Debug.Log("Testing");
        foreach (SoundEffect sound in soundEffects)
        {
            if (sound.name.Equals(soundName))
            {
                Debug.Log("Playing " + sound.name);
                audioSource.PlayOneShot(sound.sound, volume);
                break;
            }
            
        }
    }
    
    public static void playSound(string soundName, float volume)
    {
        instance.playSoundInstance(soundName, volume);
    }

    
}

[System.Serializable]
public class SoundEffect
{
    public string name;
    public AudioClip sound;

}
