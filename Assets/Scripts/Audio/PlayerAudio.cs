using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gunAudio;

    public void PlayGunSound()
    {
        audioSource.PlayOneShot(gunAudio);
    }
}
