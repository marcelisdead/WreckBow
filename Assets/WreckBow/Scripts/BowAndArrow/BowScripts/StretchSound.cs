using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays audio when normalized value amount is changing. amount also effects that sound's pitches.
/// Also Curves volume when becoming quiet to stop ugly sound cracking.
/// Made for bow stretching sound but could also make door, floor, or lever's creaking or a scaling noises
/// </summary>

public class StretchSound : MonoBehaviour
{
    public AudioSource aSource;
    public float minPitch = .25f;
    public float maxPitch = .55f;

    public float minVolume = 0f;
    public float maxVolume = 1f;
    public float volumeCurve = 0.001f;

    public float stretchSpeed = .6f;

    [Range(0,1)]
    public float amount = 0f;

    float _lastPitch = 0f;
    bool _isPaused;

    private void Start()
    {
        aSource.volume = 0;
        aSource.Play();
    }

    void Update()
    {
        //amount = grab.forceAmount;

        float newPitch = Mathf.Lerp(aSource.pitch, Mathf.Lerp(minPitch, maxPitch, amount), stretchSpeed);
        if (Mathf.Abs(newPitch - _lastPitch) < volumeCurve)
        {
            aSource.volume = Mathf.Lerp(maxVolume, minVolume, 1-Mathf.Abs(newPitch - _lastPitch) / volumeCurve);

                //aSource.Pause();
                _isPaused = true;
        }

        else
        {
            if (_isPaused)
            {
                //aSource.Play();
                aSource.volume = maxVolume;
                _isPaused = false;
            }
            aSource.pitch = newPitch;
        }
        _lastPitch = newPitch;
    }

    public void SetAmount(float setAmount)
    {
        amount = setAmount;
    }
}
