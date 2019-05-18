using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TouchScript.Gestures;

/*とげの伸び縮み
 */


public class TogeScript : MonoBehaviour {
    public GameObject[] toge;
    public TapGesture tapGesture;
    public int frame;
    private bool nobi = false;

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
        if (nobi == false)
        {
            Debug.Log("タップされた");
            toge[0].transform.localScale += new Vector3(0, 1.5f);
            nobi = true;
            frame = 0;
        }


    }




    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        frame++;
        if (frame > 0.5 / Time.deltaTime && nobi == true)//とげの伸びが戻る
        {
            toge[0].transform.localScale -= new Vector3(0, 1.5f);
            nobi = false;
        }

    }

    
}
