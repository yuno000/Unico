using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 /*うにの体力
  * ゲームオーバーシーンへの遷移
  * うにの回転
  */

public class UniScript : MonoBehaviour {
    public int uniHP　= 5;
    int maxHP = 5;
    public Slider hpSlider;
    
    

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
