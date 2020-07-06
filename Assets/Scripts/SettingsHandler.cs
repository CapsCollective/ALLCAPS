using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    private Dropdown _resolutionSelect;
    private Toggle _fullscreenToggle;
    private Slider _volumeSlider;
    
    private Resolution[] _resolutions;

    void Start()
    {
        _resolutionSelect = GameObject.Find("ResolutionSelect").GetComponent<Dropdown>();
        _fullscreenToggle = GameObject.Find("FullscreenToggle").GetComponent<Toggle>();
        _volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        _resolutions = Screen.resolutions;
        _resolutionSelect.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string optionText = _resolutions[i].width + " x " + _resolutions[i].height + " " + _resolutions[i].refreshRate + "Hz";
            options.Add(optionText);
        }
        _resolutionSelect.AddOptions(options);
        
        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        SetFullScreen(isFullscreen);
        _fullscreenToggle.isOn = isFullscreen;
        
        int res = PlayerPrefs.GetInt("Resolution", _resolutions.Length - 1); //Default to max res
        SetResolution(res);
        _resolutionSelect.value = res;
        
        float val = PlayerPrefs.GetFloat("Volume", _volumeSlider.maxValue);
        SetVolume(val);
        _volumeSlider.value = val;
    }
    
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }

    public void SetVolume(float volume)
    {
        _volumeSlider.value = volume;
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
