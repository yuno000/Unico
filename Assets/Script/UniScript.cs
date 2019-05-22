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
    public AudioClip damageSound;
    AudioSource audioSource;
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
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = damageSound;
        

    }
	
	// Update is called once per frame
	void Update () {
        unicotimer += Time.deltaTime;
        uniHpLabel.text = uniHP.ToString() + "/5";
        if(unicodamage == true && unicotimer > 1.5f)
        {
            script.ChangeDamageToHold();
        }

        if (uniHP == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(uniHP > 0) {
            if (collision.gameObject.tag == ("Enemy"))
            {
                audioSource.Play();
                unicotimer = 0;
                script.ChangeHoldToDamage();
                unicodamage = true;
                Debug.Log(collision.gameObject.name);
                uniHP--;
                hpSlider.value--;
                Destroy(collision.gameObject);
            }
        }
    }

}
