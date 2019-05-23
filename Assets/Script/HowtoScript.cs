using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowtoScript : MonoBehaviour {
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
    public void ToHowtoButton()
    {
        audioSource.Play();
        SceneManager.LoadScene("HowtoPlay");
    }
}
