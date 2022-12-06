using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    int level;
    public MusicController musicController;
    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        level = SaveSystem.LoadLevel();
        AudioSource audioSource = musicController.gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.1f;
        switch (level)
        {
            case 1: //level 1
                audioSource.clip = audioClips[1];
                break;
            case 2: // level 2
                audioSource.clip = audioClips[2];
                break;
            case 3: //level 3
                audioSource.clip = audioClips[3];
                break;
            default: //main menu sounds
                audioSource.clip = audioClips[0];
                break;
        }

        audioSource.Play();
    }
}
