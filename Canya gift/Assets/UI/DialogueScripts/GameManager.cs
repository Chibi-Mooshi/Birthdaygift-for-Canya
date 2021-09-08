using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;

        if (instance == null)
        {
            instance = this;
        }
    }
    
}

