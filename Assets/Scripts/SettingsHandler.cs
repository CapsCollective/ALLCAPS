using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class SettingsHandler : MonoBehaviour
{
    private Dropdown _resolutionSelect;
    private Toggle _fullscreenToggle;
    private Slider _volumeSlider;
    
    private Resolution[] _resolutions;
    
    public float masterVolume = 1;
    public bool isFullscreen = true;
    public int resWidth = 1920;
    public int resHeight = 1080;
    
    void Start()
    {
        _resolutionSelect = GameObject.Find("ResolutionSelect").GetComponent<Dropdown>();
        _fullscreenToggle = GameObject.Find("FullscreenToggle").GetComponent<Toggle>();
        _volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        
        LoadSettings();
        
        Screen.SetResolution(resWidth, resHeight, isFullscreen);
        // Set resolution dropdown
        _resolutions = Screen.resolutions;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string res = _resolutions[i].ToString();
            _resolutionSelect.options.Add(new Dropdown.OptionData(res.Remove(res.Length-7)));
            if (Screen.currentResolution.ToString().Equals(res))
            {
                _resolutionSelect.value = i;
            }
        }
        _fullscreenToggle.isOn = isFullscreen;
        _volumeSlider.value = masterVolume;
    }
    
    public void LoadSettings()
    {
        if (!File.Exists(Application.persistentDataPath + "/settings.json")) return;
        string readString = File.ReadAllText(Application.persistentDataPath + "/settings.json");
        JsonUtility.FromJsonOverwrite(readString, this);
    }
    
    public void SaveSettings()
    {
        masterVolume = _volumeSlider.value;
        var res = _resolutions[_resolutionSelect.value];
        resHeight = res.height;
        resWidth = res.width;
        isFullscreen = _fullscreenToggle.isOn;
        
        if (File.Exists(Application.persistentDataPath + "/settings.json"))
        {
            File.Delete(Application.persistentDataPath + "/settings.json");
        }
        File.WriteAllText(Application.persistentDataPath + "/settings.json", JsonUtility.ToJson(this));
    }

    public void SetResolution()
    {
        var res = _resolutions[_resolutionSelect.value];
        Screen.SetResolution(res.width, res.height, _fullscreenToggle.isOn);
    }

    public void SetSound()
    {
        AudioListener.volume = masterVolume;
    }
    
}
