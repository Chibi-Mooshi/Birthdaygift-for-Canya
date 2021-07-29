using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToPlayer : MonoBehaviour
{
    [Tooltip("Player will appear here during in play")] public Transform target;

    [Tooltip("How close does the player need to get for sound to play?")] public float chaseRadius;

    [Tooltip("What sound should play?")]
    public AudioClip soundClip;

    private bool playerInSightRange;
    private AudioSource audioSource;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        audioSource = GetComponent<AudioSource>();


    }

    private void Update()
    {

        Debug.Log(playerInSightRange);
        if (Vector2.Distance(transform.position, target.position) < chaseRadius)
        {
            
            playerInSightRange = true;
        }
        else
        {
            playerInSightRange = false;
        }

        if (playerInSightRange && !audioSource.isPlaying)
        {
            playSoundClip();
        } 
    }

    void playSoundClip()
    {
        audioSource.PlayOneShot(soundClip);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}