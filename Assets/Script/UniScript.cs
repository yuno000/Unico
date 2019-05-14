using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TouchScript.Gestures.TransformGestures;


 /* うにの回転
  * うにの体力
  * ゲームオーバーシーンへの遷移
  */

public class UniScript : MonoBehaviour {
    public int uniHP　= 5;
    int maxHP = 5;
    public Slider hpSlider;
    public PinnedTransformGesture transformGesture;


    private void OnEnable()
    {
        transformGesture.TransformStarted += OnTransformStarted;
        transformGesture.Transformed += OnTransformed;
        transformGesture.TransformCompleted += OnTransformCompleted;
    }

    private void OnDisable()
    {
        transformGesture.TransformStarted -= OnTransformStarted;
        transformGesture.Transformed -= OnTransformed;
        transformGesture.TransformCompleted -= OnTransformCompleted;
    }

    private void OnTransformStarted(object sender, EventArgs e)
    {
        Debug.Log("変形を開始した");
    }

    private void OnTransformed(object sender, EventArgs e)
    {
        var g = transformGesture;
        var sb = new StringBuilder();
        sb.AppendLine("変形中");
        sb.AppendLine("DeltaRotation: " + g.DeltaRotation);
        Debug.Log(sb);
    }

    private void OnTransformCompleted(object sender, EventArgs e)
    {
        Debug.Log("変形を完了した");
    }



    // Use this for initialization
    void Start () {
        hpSlider.maxValue = maxHP;
        hpSlider.value = uniHP;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(uniHP > 0) {
            if (collision.gameObject.tag == ("Enemy"))
            {
                uniHP--;
                hpSlider.value--;
            }
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
