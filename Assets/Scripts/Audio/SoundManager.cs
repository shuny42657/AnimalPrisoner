using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.llamagod;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// Written by Shinnosuke (2024/9/25)
    /// </summary>
    public class SoundData
    {
        public AudioClip audioClip;
        [Range(0f, 1f)] public float volume;
    }
    [System.Serializable]
    public class BGMSoundData : SoundData
    {
        public enum BGM
        {
            Title,
            Menu,
            Game,
        }
        public BGM bgm;
    }
    [System.Serializable]
    public class SESoundData : SoundData
    {
        public enum SE
        {
            Decide,
            Cancel,
        }
        public SE se;
    }
    public BGMSoundData[] bgmSoundDatas;
    public SESoundData[] seSoundDatas;
    private Dictionary<BGMSoundData.BGM, BGMSoundData> bgmSoundDictionary = new Dictionary<BGMSoundData.BGM, BGMSoundData>();
    private Dictionary<SESoundData.SE, SESoundData> seSoundDictionary = new Dictionary<SESoundData.SE, SESoundData>();
    private AudioSource[] seAudioSources = new AudioSource[10]; // Multiple SEs are played simultaneously.
    private AudioSource bgmAudioSource; // One BGM is played at a time.
    public static SoundManager Instance { private set; get; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < seAudioSources.Length; i++) seAudioSources[i] = gameObject.AddComponent<AudioSource>();
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        foreach (var bgmSoundData in bgmSoundDatas) bgmSoundDictionary.Add(bgmSoundData.bgm, bgmSoundData);
        foreach (var seSoundData in seSoundDatas) seSoundDictionary.Add(seSoundData.se, seSoundData);
    }
    [EnumAction(typeof(BGMSoundData.BGM))]
    public void PlayBGM(int bgm)
    {
        BGMSoundData.BGM enumBGM = (BGMSoundData.BGM)bgm;
        if (bgmSoundDictionary.TryGetValue(enumBGM, out var soundData))
        {
            if (bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Stop();
            }
            bgmAudioSource.clip = soundData.audioClip;
            bgmAudioSource.volume = soundData.volume;
            bgmAudioSource.PlayOneShot(soundData.audioClip);
        }
        else
        {
            Debug.LogWarning("Audio clip not found");
        }
    }
    [EnumAction(typeof(SESoundData.SE))]
    public void PlaySE(int se)
    {
        SESoundData.SE enumSE = (SESoundData.SE)se;
        if (seSoundDictionary.TryGetValue(enumSE, out var soundData))
        {
            var seAudioSource = GetSEAudioSource();
            if (seAudioSource == null) return;
            seAudioSource.clip = soundData.audioClip;
            seAudioSource.volume = soundData.volume;
            seAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio clip not found");
        }
    }
    public AudioSource GetSEAudioSource()
    {
        for (int i = 0; i < seAudioSources.Length; i++)
        {
            if (!seAudioSources[i].isPlaying)
            {
                return seAudioSources[i];
            }
        }
        return null;
    }
    public void AAAAAAAA()
    {
        Debug.Log("AAAAAAAA");
    }
}
