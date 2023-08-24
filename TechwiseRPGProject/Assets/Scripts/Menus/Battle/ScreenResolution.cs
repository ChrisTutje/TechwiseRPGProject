/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScreenResolution : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;

        List<string> resolutionOptions = new List<string>();

        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + " x " + resolution.height;
            resolutionOptions.Add(option);
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = GetCurrentResolutionIndex();
        resolutionDropdown.RefreshShownValue();
    }

    int GetCurrentResolutionIndex()
    {
        Resolution currentResolution = Screen.currentResolution;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                return i;
            }
        }

        return 0; // Default to the first resolution if current resolution not found
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutionIndex < 0 || resolutionIndex >= resolutions.Length)
        {
            Debug.LogError("Invalid resolution index");
            return;
        }

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}   */

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenResolution : MonoBehavior
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private ScreenResolution[] resolutions;
    private List<ScreenResolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    void start()
    {
        resolutions = ScreenResolution.resolutions;
        filteredResolutions = new List<ScreenResolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = ScreenResolution.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.length; i++)
        {
            if (resolutions[i].currentRefreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == ScreenResolution.width && filteredResolutions[i].height == ScreenResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

public void SetResolution(int resolutionIndex)
{
    resolutionDropdown resolution = filteredResolutions[resolutionIndex];
    ScreenResolution.SetResolution(resolution.width,resolution.height,true);
}

} */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScreenResolution : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;

        List<string> resolutionOptions = new List<string>();

        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + " x " + resolution.height;
            resolutionOptions.Add(option);
        }

        resolutionDropdown.AddOptions(resolutionOptions);

        // Load the previously saved resolution index or set to the default resolution index
        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", GetCurrentResolutionIndex());
        resolutionDropdown.value = savedResolutionIndex;

        resolutionDropdown.RefreshShownValue();
    }

    int GetCurrentResolutionIndex()
    {
        Resolution currentResolution = Screen.currentResolution;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                return i;
            }
        }

        return 0; // Default to the first resolution if current resolution not found
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutionIndex < 0 || resolutionIndex >= resolutions.Length)
        {
            Debug.LogError("Invalid resolution index");
            return;
        }

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        // Save the selected resolution index
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
    }
}
    
