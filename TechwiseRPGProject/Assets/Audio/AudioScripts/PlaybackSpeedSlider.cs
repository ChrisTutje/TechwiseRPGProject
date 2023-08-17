using UnityEngine;
using UnityEngine.UI;

public class PlaybackSpeedSlider : MonoBehaviour
{
    public SoundTestController soundTestController;
    public Slider speedSlider;

    private void Start()
    {
        speedSlider.onValueChanged.AddListener(ChangePitch);
    }

    private void ChangePitch(float newPitch)
    {
        if (soundTestController != null)
        {
            soundTestController.SetPitch(newPitch);
        }
    }
}