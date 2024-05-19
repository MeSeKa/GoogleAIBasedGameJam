using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] AudioSource blastSound;

    [SerializeField] AudioSource nothingSound;


    private void Awake()
    {
        Instance = this;
    }


    public void BlastSound()
    {
        blastSound.Play();
    }
    public void NothingSound()
    {
        nothingSound.Play();
    }
}
