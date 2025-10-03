using UnityEngine;

public class SoundTantou : MonoBehaviour
{
    public static bool soundstay;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (!soundstay && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    void Update()
    {
        if (soundstay)
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Pause();
            }
            soundstay = false; // 1‰ñ‚¾‚¯Ž~‚ß‚é
        }
    }
}
