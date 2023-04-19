using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuLogic : MonoBehaviour
{
    [SerializeField] GameSettings settings;

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider sliderMaster;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderEffects;
    void OnEnable()
    {
        sliderEffects.value = settings.volumeEffects;
        UpdateEffectsVolume();
        sliderMusic.value = settings.volumeMusic;
        UpdateMusicVolume();
        sliderMaster.value = settings.volumeMaster;
        UpdateMasterVolume();
    }
    public void UpdateEffectsVolume()
    {
        audioMixer.SetFloat("VolumeEffects", sliderEffects.value);
        audioMixer.GetFloat("VolumeEffects", out settings.volumeEffects);
    }
    public void UpdateMusicVolume()
    {
        audioMixer.SetFloat("VolumeMusic", sliderMusic.value);
        audioMixer.GetFloat("VolumeMusic", out settings.volumeMusic);
    }
    public void UpdateMasterVolume()
    {
        audioMixer.SetFloat("VolumeMaster", sliderMaster.value);
        audioMixer.GetFloat("VolumeMaster", out settings.volumeMaster);
    }
}
