using UnityEngine;

public class DistanceToPlayer : MonoBehaviour
{
    
    [Tooltip("Player will appear here during in play")] public Transform target;

    [Tooltip("What randonm sound clips should play in this level?")]
    public AudioClip[] soundEffects;


    [Space(10)]

    [Tooltip("How long should minimum pass before a sound is played?")]
    public float minTimer;
    [Tooltip("How long should maximum pass before a sound is played?")]
    public float maxTimer;



    private AudioSource audioSource;
    public float minDist = 1;
    public float maxDist = 400;


    private int randomSound;

    private float timer;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        audioSource = GetComponent<AudioSource>();

        timer = Random.Range(minTimer, maxTimer);
    }

    private void Update()
    {

        float dist = Vector3.Distance(transform.position, target.position);

        if (dist < minDist)
        {
            audioSource.volume = 1;
        }
        else if (dist > maxDist)
        {
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = 1 - ((dist - minDist) / (maxDist - minDist));
        }


        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            PlayRandomSound();
        }

        Debug.Log(timer);
    }

    void PlayRandomSound()
    {
        randomSound = Random.Range(0, soundEffects.Length);
        audioSource.PlayOneShot(soundEffects[randomSound]);

        timer = Random.Range(minTimer, maxTimer);
    }


    void playSoundClip()
    {
        //audioSource.PlayOneShot(soundClip);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, maxDist);
    }
}