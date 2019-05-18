using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class TogeScript2 : MonoBehaviour {

    public GameObject[] toge;
    public int frame;
    private bool nobi = false;
    private bool tap;



    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frame++;
        if (frame > 0.5 / Time.deltaTime && nobi == true)//とげの伸びが戻る
        {
            toge[0].transform.localScale -= new Vector3(0, 1.5f);
            nobi = false;
        }
    }

    public void OnTapped()
    {
        toge[0].transform.localScale += new Vector3(0, 1.5f);
        nobi = true;
        frame = 0;
        Debug.Log("タップされました");
    }
}
