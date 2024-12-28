using UnityEngine;
public enum SoundType
{
    Flip,
    Match,
    Mismatch,
    MatchWin,
    GameWin
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip flipSound;
    [SerializeField] private AudioClip matchSound;
    [SerializeField] private AudioClip mismatchSound;
    [SerializeField] private AudioClip matchWinSound;
    [SerializeField] private AudioClip gameWinSound;

    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySound(SoundType soundType)
    {
        if (audioSource == null)
        {
            return;
        }
        AudioClip clip = GetAudioClip(soundType);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetAudioClip(SoundType soundType)
    {
        return soundType switch
        {
            SoundType.Flip => flipSound,
            SoundType.Match => matchSound,
            SoundType.Mismatch => mismatchSound,
            SoundType.MatchWin => matchWinSound,
            SoundType.GameWin => gameWinSound,
            _ => null
        };
    }
}
