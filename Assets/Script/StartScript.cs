using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
    public GameObject startEffect;
    public AudioClip startSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = startSound;


    }

    // Update is called once per frame
    void Update () {
		
	}

    public void StartButton()
    {
        audioSource.Play();
        SceneManager.LoadScene("Main");
        Instantiate(startEffect, this.transform.position, Quaternion.identity);
    }
}
