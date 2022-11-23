using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    //[Header("Main Settings:")]
    //[Range(0, 1)] [SerializeField] private float musicVolume;
    //[Range(0, 1)] [SerializeField] private float sfxVolume;

    public AudioSource musicAudioSource;
    public AudioSource soundAudioSource;


    [Header("music")]

    [SerializeField] private AudioClip[] bgMusics;

    [Header("Game Sounds")] 
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip[] dies;
    [SerializeField] private AudioClip[] weaponHits;
    [SerializeField] private AudioClip[] weaponThrows;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip lose;


   

    //private const string VOLUME_ON = "VolumeOn";
    
    // Start is called before the first frame update
    void Start()
    {
        PlayMusics(bgMusics, true);
    }

    //public void SwitchVolumeOn()
    //{
    //    SetVolumeOn(!isVolumeOn);
    //}
    
    //public void SetVolumeOn(bool isVolumeOne)
    //{
    //    PlayerPrefs.SetInt(VOLUME_ON, isVolumeOne ? 1 : 0);
    //    RefreshStatusSounds();
    //}

    //public bool isVolumeOn => PlayerPrefs.GetInt(VOLUME_ON, 1) == 1;
    
    public void PlaySound(AudioClip sound)
    {
        if (soundAudioSource != null )
        {
            soundAudioSource.PlayOneShot(sound);
        }
    }
   
    public void PlaySounds(AudioClip[] sounds)
    {
        PlaySound(sounds[Random.Range(0, sounds.Length)]);
    }


    public void PlayMusic(AudioClip music, bool loop = true)
    {
        if (musicAudioSource != null )
        {
            musicAudioSource.clip = music;
            musicAudioSource.loop = loop;
            musicAudioSource.Play();
        }
    }
    public void PlayMusics(AudioClip[] musics, bool loop = true)
    {
        if (musics.Length > 0)
        {
            PlayMusic(musics[Random.Range(0, musics.Length)], loop);
        }
    }
    //private void RefreshStatusSounds()
    //{
    //    if (isVolumeOn)
    //    {
    //        if (!musicAudioSource.isPlaying)
    //        {
    //            PlayMusics(bgMusics, true);
    //        }
    //    }
    //    else
    //    {
    //        if (musicAudioSource.isPlaying)
    //        {
    //            musicAudioSource.Pause();
    //        }
    //    }
    //}
    
    public void WeaponHit()
    {
        PlaySounds(weaponHits);
    }
    public void ThrowWeapon()
    {
        PlaySounds(weaponThrows);
    }
    public void GameOver()
    {
        PlaySound(lose);
    }
    public void Victory()
    {
        PlaySound(win);
    }
    public void Died()
    {
        PlaySounds(dies);
    }
    public void ButtonClick()
    {
        PlaySound(buttonClick);
    }
    
}
