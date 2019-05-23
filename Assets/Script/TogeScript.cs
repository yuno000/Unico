using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TouchScript.Gestures;
using UnityEngine.UI;

/*とげの伸び縮み
 *魚ととげが当たったら音が鳴る
 */


public class TogeScript : MonoBehaviour
{
    public GameObject[] toge;
    public TapGesture tapGesture;
    public int frame;
    public bool nobi = false;
    public AudioClip nobiSound;
    AudioSource audioSource;


    //タップされると伸びる
    private void OnEnable()
    {
       // toge[0].GetComponent<Nobi>().nobi = true;
        tapGesture.Tapped += OnTapped;
    }

    private void OnDisable()
    {
        tapGesture.Tapped -= OnTapped;
    }

    private void OnTapped(object sender, EventArgs e)
    {
        if (nobi == false)
        {
            audioSource.Play();
            toge[0].transform.localScale += new Vector3(0, 2.0f);
            nobi = true;
            Nobi.nobi = nobi;
            frame = 0;
        }


    }




    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = nobiSound;
         Nobi.nobi = nobi;
    }

    // Update is called once per frame
    void Update()
    {

        frame++;
        if (frame > 0.5 / Time.deltaTime && nobi == true)//とげの伸びが戻る
        {
            toge[0].transform.localScale -= new Vector3(0, 2.0f);
            nobi = false;
            Nobi.nobi = nobi;
        }

    }
}
