using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tostart : MonoBehaviour
{
    public AudioClip startSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = startSound;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnButton()
    {
        Debug.Log("おされた");
        //audioSource.Play();
        SceneManager.LoadScene("Start");
    }
}
