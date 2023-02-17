using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;


    [SerializeField] List<AudioClip> SoundsList;
    AudioSource audioSource;

    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();            
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(SoundsList[index]);
    }

    


}
