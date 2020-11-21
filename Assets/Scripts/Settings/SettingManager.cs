using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public TMP_Dropdown resolutionDropdown;
    public Resolution[] Resolutions;
    public TMP_Dropdown qualityDropdown;

    public Slider volumeMasterSlider;
    public Slider volumeMusicSlider;
    public Slider volumeSfxSlider;

    public TMP_Dropdown keyBindingDropdown;

    public GameSettings gameSettings;

    private AudioManager _audioManager;

    private void OnEnable()
    {
        gameSettings = new GameSettings();

        InitResolutions();
        
        _audioManager = AudioManager.Instance;
        Assert.IsNotNull(_audioManager);
        
        InitListener();
        
    }

    private void Start()
    {
        LoadSettings();
    }
    
    public void InitResolutions()
    {
        Resolutions = Screen.resolutions;
        List<String> options = new List<string>();

        int currentResolutionIndex = 0;
        
        for(int i = 0; i <Resolutions.Length; i++)
        {
            string option = Resolutions[i].width + " x " + Resolutions[i].height + " @ " + Resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (Resolutions[i].width == Screen.currentResolution.width && 
                Resolutions[i].height == Screen.currentResolution.height && 
                 Resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    
    public void InitListener()
    {
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        qualityDropdown.onValueChanged.AddListener(delegate { OnQualityChange(); });
        volumeMasterSlider.onValueChanged.AddListener(delegate { OnMasterVolumeChange(); });
        volumeMusicSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        volumeSfxSlider.onValueChanged.AddListener(delegate { OnSfxVolumeChange(); });
        keyBindingDropdown.onValueChanged.AddListener(delegate { OnKeyBindingChange(); });
    }

    public void OnFullScreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
        Debug.Log("Toggle fullscreen to " + Screen.fullScreen);
        SaveSettings();
    }

    public void OnResolutionChange()
    {
        Resolution resolution = gameSettings.Resolution = Resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log("Set Resolution to" + Screen.currentResolution);
        SaveSettings();
    }

    public void OnQualityChange()
    {
        QualitySettings.SetQualityLevel(gameSettings.qualityIndex = qualityDropdown.value);
        Debug.Log("Set Quality Level to " + QualitySettings.GetQualityLevel());
        SaveSettings();
    }

    public void OnMasterVolumeChange()
    {
        _audioManager.SetVolumeAudioMaster(gameSettings.volumeMaster = volumeMasterSlider.value);
        Debug.Log("Set Master Audio Volume to " + gameSettings.volumeMaster);
        SaveSettings();
    }
    
    public void OnMusicVolumeChange()
    {
        _audioManager.SetVolumeAudioMusic(gameSettings.volumeMusic = volumeMusicSlider.value);
        Debug.Log("Set Music Audio Volume to " + gameSettings.volumeMusic);
        SaveSettings();
    }
    
    public void OnSfxVolumeChange()
    {
        _audioManager.SetVolumeAudioSfx(gameSettings.volumeSfx = volumeSfxSlider.value);
        Debug.Log("Set Sfx Audio Volume to " + gameSettings.volumeSfx);
        SaveSettings();
    }
    
    public void OnKeyBindingChange()
    {
        // TODO : Add keybinding Option.
        gameSettings.keyBinding = keyBindingDropdown.value;
        Debug.Log("Set Keybinding to " + gameSettings.keyBinding);
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("Fullscreen", gameSettings.fullscreen?1:0);
        PlayerPrefs.SetInt("ResolutionWidth", gameSettings.Resolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", gameSettings.Resolution.height);
        PlayerPrefs.SetInt("ResolutionRefreshRate", gameSettings.Resolution.refreshRate);
        PlayerPrefs.SetInt("QualityIndex", gameSettings.qualityIndex);
        PlayerPrefs.SetFloat("VolumeMaster", gameSettings.volumeMaster);
        PlayerPrefs.SetFloat("VolumeMusic", gameSettings.volumeMusic);
        PlayerPrefs.SetFloat("VolumeSfx", gameSettings.volumeSfx);
        PlayerPrefs.SetInt("KeyBinding",gameSettings.keyBinding);
    }

    public void LoadSettings()
    {
        gameSettings.fullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        gameSettings.Resolution.height = PlayerPrefs.GetInt("ResolutionHeight", 960);
        gameSettings.Resolution.width = PlayerPrefs.GetInt("ResolutionWidth", 540);
        gameSettings.Resolution.refreshRate = PlayerPrefs.GetInt("ResolutionWidth", 60);
        gameSettings.qualityIndex = PlayerPrefs.GetInt("QualityIndex", 1);
        gameSettings.volumeMaster = PlayerPrefs.GetFloat("VolumeMaster", 80f);
        gameSettings.volumeMusic = PlayerPrefs.GetFloat("VolumeMusic", 80f);
        gameSettings.volumeSfx = PlayerPrefs.GetFloat("VolumeSfx", 80f);
        gameSettings.keyBinding = PlayerPrefs.GetInt("KeyBinding", 0);
        
        fullscreenToggle.isOn = gameSettings.fullscreen;
        qualityDropdown.value = gameSettings.qualityIndex;
        volumeMasterSlider.value = gameSettings.volumeMaster;
        volumeMusicSlider.value = gameSettings.volumeMusic;
        volumeSfxSlider.value = gameSettings.volumeSfx;

        keyBindingDropdown.value = gameSettings.keyBinding;
    }
    
}
