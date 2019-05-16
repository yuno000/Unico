using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
    public GameObject startEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartButton()
    {
        SceneManager.LoadScene("Main");
        Instantiate(startEffect, this.transform.position, Quaternion.identity);
    }
}
