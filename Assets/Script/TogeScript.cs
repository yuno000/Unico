using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TouchScript.Gestures;

public class TogeScript : MonoBehaviour {
    public GameObject[] toge;
    public TapGesture tapGesture;
    public float timer; 

    //タップされると伸びる
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
        timer = 0;
        toge[0].transform.localScale += new Vector3(0, 0.5f);

       
    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        timer = Time.deltaTime;
        if (timer > 0.5f && toge[0].transform.localScale.y > 0.8f )
        {
            toge[0].transform.localScale -= new Vector3(0, 0.5f);
            Debug.Log(timer);
        }


    }
}
