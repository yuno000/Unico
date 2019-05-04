using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TouchScript.Gestures;

public class TogeScript : MonoBehaviour {
    public GameObject[] toge;
    public TapGesture tapGesture;


    private void OnEnable()
    {

        tapGesture.Tapped += OnTapped;
    }

    private void OnDisable()
    {
        tapGesture.Tapped -= OnTapped;
    }

    private void OnTapped(object sender, EventArgs e)
    {
        Debug.Log("タップされた");
    }


    //void HandleTapped(object sender, System.EventArgs e)
    //{
    //    toge[0].transform.localScale = new Vector2(0, 40);
    //    Debug.Log("tap"); 
    //}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
