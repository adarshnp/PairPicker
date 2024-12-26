using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioClip flipSound;
    [SerializeField] private AudioClip matchSound;
    [SerializeField] private AudioClip mismatchSound;
    [SerializeField] private AudioClip matchWinSound;
    [SerializeField] private AudioClip gameWinSound;

    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayFlipSound()
    {
        audioSource.PlayOneShot(flipSound);
    }

    public void PlayMatchSound()
    {
        audioSource.PlayOneShot(matchSound);
    }

    public void PlayMismatchSound()
    {
        audioSource.PlayOneShot(mismatchSound);
    }

    public void PlayMatchWinSound()
    {
        audioSource.PlayOneShot(matchWinSound);
    }
    public void PlayGameWinSound()
    {
        audioSource.PlayOneShot(gameWinSound);
    }
}
