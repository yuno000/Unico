using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TouchScript.Gestures.TransformGestures;


 /* うにの体力
  * ウニ子表情・・・SetActiveかRendererか
  * ゲームオーバーシーンへの遷移
  */

public class UniScript : MonoBehaviour {
    public GameObject unico;
    ChangeunicoScript script;
    public int uniHP　= 5;
    public Text uniHpLabel;
    int maxHP = 5;
    public Slider hpSlider;
    SpriteRenderer MainSpriteRenderer;
    private float unicotimer;
    private bool unicodamage;
    // publicで宣言し、inspectorで設定可能にする
    //public Sprite staySprite;
    //public Sprite damageSprite;



    // Use this for initialization
    void Start () {
        hpSlider.maxValue = maxHP;
        hpSlider.value = uniHP;
        unicotimer = 0;
        unicodamage = false;
        script = unico.GetComponent<ChangeunicoScript>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        unicotimer += Time.deltaTime;
        uniHpLabel.text = uniHP.ToString() + "/5";
        if(unicodamage == true && unicotimer > 1.5f)
        {
            script.ChangeDamageToHold();
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(uniHP > 0) {
            if (collision.gameObject.tag == ("Enemy"))
            {
                unicotimer = 0;
                script.ChangeHoldToDamage();
                unicodamage = true;
                Debug.Log(collision.gameObject.name);
                uniHP--;
                hpSlider.value--;
                Destroy(collision.gameObject);
            }
        }
        else if(uniHP == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

   /* void ChangeDamageToStay()
    {
        // SpriteRenderのspriteを設定済みの他のspriteに変更
        //MainSpriteRenderer.sprite = staySprite;

    }

   // void ChangeStayToDamage()
    {
        // SpriteRenderのspriteを設定済みの他のspriteに変更
        MainSpriteRenderer.sprite = damageSprite;
    }*/
}
