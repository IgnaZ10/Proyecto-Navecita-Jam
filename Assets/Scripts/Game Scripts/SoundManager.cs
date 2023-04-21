using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource, _SFXSource;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] GameData settings;

    public static SoundManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioMixer.SetFloat("VolumeEffects", settings.volumeEffects);
        audioMixer.SetFloat("VolumeMusic", settings.volumeMusic);
        audioMixer.SetFloat("VolumeMaster", settings.volumeMaster);
    }
    public void PlaySound(AudioClip clip)
    {
        _SFXSource.PlayOneShot(clip);
    }
}
