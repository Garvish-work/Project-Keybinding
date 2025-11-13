using UnityEngine;
using System.Collections.Generic;

public class SfxSystem : MonoBehaviour
{
    AudioSource audioSource;
    private Dictionary <SoundEffects, AudioClip> sfxList = new Dictionary <SoundEffects, AudioClip> ();

    [SerializeField] private SfxData sfxData;

    private void OnEnable()
    {
        ActionHandler.OnRequestSoundEffect += PlaySoundEffect;
    }

    private void OnDisable()
    {
        ActionHandler.OnRequestSoundEffect -= PlaySoundEffect;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();  
        PopulateDictionary();
    }

    private void PopulateDictionary()
    {
        foreach (var data in sfxData.sfxGroup)
        {
            sfxList.Add(data.sfxEffects, data.sfxClip);
        }
    }

    private void PlaySoundEffect(SoundEffects _effect)
    {
        AudioClip _selectedAudioClip = sfxList.TryGetValue (_effect, out _selectedAudioClip) ? _selectedAudioClip : null;
        audioSource.PlayOneShot(_selectedAudioClip);
    }
}
