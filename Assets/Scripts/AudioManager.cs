using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    [Header("Outputs")]
    public AudioSource masterOutput;//muzik
    public AudioSource sfxOutput;//ses efektleri
    public float maxOutputVolume = 1f;//muzigin max seviyesi
    public float startDuration = 2f;//acilis yumusakligi ayari
    [Header("Sound Effects")]
    public AudioClip TakeDamage;
    public AudioClip RestoreHealth;
    public AudioClip Interact;
    public AudioClip Shoot;
    private void Start()
    {
        StartVolumeEffect();//muzigi yumusak sekilde ac
    }
    public void StartVolumeEffect()
    {
        //sahne acildiginda muzigin sesini smooth sekilde acar
        masterOutput.volume = 0;
        ChangeVolumeMaster(maxOutputVolume, startDuration);
    }
    public void ChangeVolumeMaster(float targetValue, float duration)
    {
        //muzigin sesini artirip azalt
        masterOutput.DOFade(targetValue, duration);
    }
    public void ChangeVolumeSFX(float targetValue, float duration)
    {
        //ses efektlerinin sesini artirip azalt
        sfxOutput.DOFade(targetValue, duration);
    }
    public void PlaySoundEffect(AudioClip audioClip)
    {
        //ses efekti cal
        sfxOutput.PlayOneShot(audioClip, 1f);
    }
}
