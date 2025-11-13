using UnityEngine;

[CreateAssetMenu (fileName = "Sfx data", menuName = "Scriptable/Sfx data")]
public class SfxData : ScriptableObject
{
    public SfxGroup[] sfxGroup;
}

[System.Serializable]
public struct SfxGroup
{
    public SoundEffects sfxEffects;
    public AudioClip sfxClip;
}
