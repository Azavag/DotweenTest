using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraTween : MonoBehaviour
{
    [SerializeField] bool cameraShake;
    [SerializeField] Camera cam;
    [SerializeField] Transform objectToShake;
    [SerializeField] float strength, randomness;
    [SerializeField] int vibarato;
    [SerializeField] bool isFadeOut;
    [SerializeField] ShakeRandomnessMode randomnessMode;
    [SerializeField] float duration;
    void Start()
    {
        
    }

    public void StartShake()
    {
        if(cameraShake) 
        {
            cam.DOShakePosition(
            duration: duration,
            strength: strength,
            vibrato: vibarato,
            randomness: randomness,
            fadeOut: isFadeOut,
            randomnessMode: randomnessMode)
            .Play()
            .OnComplete(() => { cam.DORewind(); cam.DOKill(); });
            
        }
        else
        {
            objectToShake.DOShakePosition(
            duration: duration,
            strength: strength,
            vibrato: vibarato,
            randomness: randomness, 
            fadeOut: isFadeOut,
            randomnessMode: randomnessMode)
            .Play()
            .OnComplete(() => { objectToShake.DORewind(); objectToShake.DOKill(); });


        }
        
    }
}
