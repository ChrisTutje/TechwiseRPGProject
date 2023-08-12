using UnityEngine;
using UnityEngine.UI;

public class SoundTestController : MonoBehaviour
{
    public Text trackSelectionText; 
    public AudioClip[] musicTracks;
    public AudioSource audioSource0; //I tried making this section an array, however it created index errors in between objects
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    public AudioSource audioSource6;

    public AudioSource audioSource7;
    public AudioSource audioSource8;
    public AudioSource audioSource9;
    public AudioSource audioSource10;
    public AudioSource audioSource11;
    public AudioSource audioSource12;
    public AudioSource audioSource13;
    public AudioSource audioSource14;
    public AudioSource audioSource15;
    

    private int currentTrackIndex = 0;
    private AudioSource currentAudioSource;

    private void Start()
    {
        UpdateTrackSelectionText();
        InitializePitch();
    }

    public void Play()
    {
        StopAllAudio();

        currentAudioSource = GetCurrentAudioSource();
        if (currentAudioSource != null)
        {
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
        StopAllAudio();
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        UpdateTrackSelectionText();
    }

    public void PreviousTrack()
    {
        StopAllAudio();
        currentTrackIndex = (currentTrackIndex - 1 + musicTracks.Length) % musicTracks.Length;
        UpdateTrackSelectionText();
    }

    private void StopAllAudio()
    {
        if (currentAudioSource != null)
        {
            currentAudioSource.Stop();
        }
    }

    private AudioSource GetCurrentAudioSource()
    {
        switch (currentTrackIndex)
        {
            case 0: return audioSource0;
            case 1: return audioSource1;
            case 2: return audioSource2;
            case 3: return audioSource3;
            case 4: return audioSource4;
            case 5: return audioSource5;

            case 6: return audioSource6;
            case 7: return audioSource7;
            case 8: return audioSource8;
            case 9: return audioSource9;
            case 10: return audioSource10;
            case 11: return audioSource11;
            case 12: return audioSource12;
            case 13: return audioSource13;
            case 14: return audioSource14;
            case 15: return audioSource15;
            default: return null;
        }
    }

    private void UpdateTrackSelectionText()
    {
        if (currentTrackIndex >= 0 && currentTrackIndex < musicTracks.Length)
        {
            trackSelectionText.text = musicTracks[currentTrackIndex].name;
        }
    }

    private void InitializePitch()
{
    audioSource0.pitch = 1.0f;
    audioSource1.pitch = 1.0f;
    audioSource2.pitch = 1.0f;
    audioSource3.pitch = 1.0f;
    audioSource4.pitch = 1.0f;
    audioSource5.pitch = 1.0f;

    audioSource6.pitch = 1.0f;
    audioSource7.pitch = 1.0f;
    audioSource8.pitch = 1.0f;
    audioSource9.pitch = 1.0f;
    audioSource10.pitch = 1.0f;
    audioSource11.pitch = 1.0f;
    audioSource12.pitch = 1.0f;
    audioSource13.pitch = 1.0f;
    audioSource14.pitch = 1.0f;
    audioSource15.pitch = 1.0f;
}

    public void SetPitch(float newPitch)
    {
        if (currentAudioSource != null)
        {
            currentAudioSource.pitch = newPitch;
        }
    }
}




