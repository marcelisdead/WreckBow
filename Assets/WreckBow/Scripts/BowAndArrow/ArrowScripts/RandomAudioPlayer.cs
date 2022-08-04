using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Randomly plays one of array clips
/// </summary>
public class RandomAudioPlayer : MonoBehaviour
{

    public AudioSource source;
    public AudioClip[] clips;


    public void PlayRandomClip()
    {
        if (source)
        {
            source.clip = clips[(int)UnityEngine.Random.Range(0, clips.Length)];
            source.Play();
        }
    }
}
