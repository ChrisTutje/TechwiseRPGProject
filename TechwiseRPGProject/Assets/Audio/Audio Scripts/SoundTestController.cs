using UnityEngine;
using UnityEngine.UI;

public class SoundTestController : MonoBehaviour
{
    public Text trackSelectionText;
    public AudioClip[] musicTracks;
    private int currentTrackIndex = 0;
    private AudioSource[] audioSources; 
    private AudioSource currentAudioSource; 

    private void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>(); 
        UpdateTrackSelectionText();
    }

    public void Play()
    {
        StopAllAudio();
        
        if (currentTrackIndex >= 0 && currentTrackIndex < musicTracks.Length)
        {
            currentAudioSource = audioSources[currentTrackIndex];
            currentAudioSource.clip = musicTracks[currentTrackIndex];
            currentAudioSource.Play();
        }
    } 

    public void Stop()
    {
        if (currentAudioSource != null)
        {
            currentAudioSource.Stop();
        }
    }

    public void NextTrack()
    {
        //currentTrackIndex = (currentTrackIndex + 1);
        currentTrackIndex += 1;
        UpdateTrackSelectionText();
    }

    public void PreviousTrack()
    {
        currentTrackIndex = (currentTrackIndex - 1 + musicTracks.Length) % musicTracks.Length ;
        UpdateTrackSelectionText();
    }

    private void StopAllAudio()
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }

    private void UpdateTrackSelectionText()
    {
        trackSelectionText.text = musicTracks[currentTrackIndex].name;
    }
}