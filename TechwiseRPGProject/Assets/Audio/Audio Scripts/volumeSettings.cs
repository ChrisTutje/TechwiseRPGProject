using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class volumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    private void Start() {
        if(PlayerPrefs.HasKey("musicVol") || PlayerPrefs.HasKey("sfxVol") ) {
            loadVolume();
        } else{
        setMusicVolume();
        setSfxVolume();

        }
    }

    public void setMusicVolume() {
        float volume = musicVolumeSlider.value;
        audioMixer.SetFloat("musicVolume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVol", volume);
    }

    public void setSfxVolume() {
        float volume = sfxVolumeSlider.value;
        audioMixer.SetFloat("sfxVolume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfxVol", volume);
    }

    private void loadVolume() {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVol");

        setMusicVolume();
        setSfxVolume();
    }
   
}
