using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakanaAudioScript : MonoBehaviour
{
    public AudioClip hitSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = hitSound;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioSource.Play();
        }
    }
}
