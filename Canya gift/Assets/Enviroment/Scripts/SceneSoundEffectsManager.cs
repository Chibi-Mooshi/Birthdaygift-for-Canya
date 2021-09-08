using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSoundEffectsManager : MonoBehaviour
{
    [Tooltip("What randonm sound clips should play in this level?")]
    public AudioClip[] soundEffects;

    
    private int randomSound;

    [Range(0,1)]
    public float maxVolume;
    [Range(0, 1)]
    public float minVolume;

    [Space(10)]

    [Tooltip("How long should minimum pass before a sound is played?")]
    public float minTimer;
    [Tooltip("How long should maximum pass before a sound is played?")]
    public float maxTimer;

    private float timer;

    private AudioSource audiosource;


    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        timer = Random.Range(minTimer, maxTimer);
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer >= 0)
        {
            PlayRandomSound();
        }

    }

    void PlayRandomSound()
    {
        randomSound = Random.Range(0, soundEffects.Length);
        audiosource.PlayOneShot(soundEffects[randomSound]);

        var newVolume = Random.Range(minVolume, maxVolume);
        audiosource.volume = newVolume;

        timer = Random.Range(minTimer,maxTimer);
    }
}
