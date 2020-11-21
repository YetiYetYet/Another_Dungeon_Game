using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct GameSettings
{
    
    public bool fullscreen;
    public Resolution Resolution;
    public int qualityIndex;
    public float volumeMaster;
    public float volumeMusic;
    public float volumeSfx;
    public int keyBinding;
}
