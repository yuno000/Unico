using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*敵（魚）のスクリプト
 * 魚の動き2秒で往復
 * 魚のHP
 * 魚とげにあたったらきえるかつスコア増える
 * 魚のRush:6秒放置したら（0,0,0）へ
 * 魚の向き
 */

public class OsakanaScript : MonoBehaviour {

    public int osakanaHP = 1;
    private int timer;
    public GameObject osakana;
    //public GameObject gameManagement;
    public GameObject uni;
    public GameObject effect;
    public GameObject damageEffect;
    private int mukirand;
    public float mukiSin;
    public float mukiCos;
    private int speed;
    private float initiateposx;
    private float initiateposy;
    private float t;
    private int trand;
    private bool rotate;
    private bool one;


    SpriteRenderer MainSpriteRenderer;
    //// publicで宣言し、inspectorで設定可能にする
    public Sprite rightSprite;
    public Sprite leftSprite;

    [SerializeField]
    GameObject _start;

    [SerializeField]
    GameObject _target;




    // Use this for initialization
    void Start ()
    {
        initiateposx = this.gameObject.transform.position.x;
        initiateposy = this.gameObject.transform.position.y;
        t = 0;
        rotate = false;
        one = false;
        trand = Random.Range(6, 13);
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;

       if(t <= trand)
        {
            if (one == false)
            {
                mukirand = Random.Range(0, 2);
                one = true;
            }
            if (mukirand == 0)
            {
                OsakanaMoveSin();
            }
            else
            {
                OsakanaMoveCos();
            }
        }
        else if(t > 6)//突撃
        {
            OsakanaRush();
            
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "toge")
        {
            Damageosakana();
            Instantiate(effect, this.transform.position, Quaternion.identity);
        }else if(collision.gameObject.name == "Circle")
        {
            Instantiate(damageEffect, this.transform.position, Quaternion.identity);
        }
    }

    void Damageosakana()
    {
        osakanaHP--;
        if(osakanaHP <= 0)
        {
            Destroy(this.gameObject);

            GameManagement.score += 100;//sakanaを倒すとスコア+100

        }
    }

    void OsakanaMoveSin()
    {
        float T = 6.0f;
        float f = 1.0f / T;
        mukiSin = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * f * trand));//周期Tでー１と１を繰り返す
     
        if (mukiSin > 0)
        {
            osakana.transform.position += new Vector3(0.03f, 0,0);
            ChangeLeftToRight();//右向きの絵ON
        }
        else if(mukiSin <= 0)
        {
            osakana.transform.position -= new Vector3(0.03f, 0,0);
            ChangeRightToLeft();//左向けの絵ON
        }

    }


    void OsakanaMoveCos()
    {

        float T2 = 6.0f;
        float f2 = 1.0f / T2;
        mukiCos = Mathf.Sign(Mathf.Cos(2 * Mathf.PI * f2 * trand));//周期Tでー１と１を繰り返す
        if (mukiCos > 0)
        {
            osakana.transform.position += new Vector3(0.03f, 0, 0);
            ChangeLeftToRight();//右向きの絵ON
        }
        else if (mukiCos <= 0)
        {
            osakana.transform.position -= new Vector3(0.03f, 0, 0);
            ChangeRightToLeft(); ;//左向けの絵ON
        }

    }



    void OsakanaRush()
    {
        speed = 1;
        float angle = GetAngle(_start.transform.position, _target.transform.position);//角度の取得

        transform.position = Vector3.MoveTowards(transform.position, new Vector2(0.0f,0.0f), speed * Time.deltaTime);//真ん中に向かう

        if (transform.position.x <= 0f && transform.position.y >= 0)//画面左上
        {
            ChangeLeftToRight();//右向きの絵
            if (rotate == false)
            {
                transform.Rotate(new Vector3(0, 0, angle - 180));
                rotate = true;
            }

        }else if(transform.position.x < 0 && transform.position.y < 0)//左下
        {
            ChangeLeftToRight();//右向きの絵
            if (rotate == false)
            {
                transform.Rotate(new Vector3(0, 0, 180 + angle));
                rotate = true;
            }

        }else if(transform.position.x > 0 && transform.position.y > 0)//右上
        {
            ChangeRightToLeft();//左向きの絵
            if (rotate == false)
            {
                transform.Rotate(new Vector3(0, 0, angle));
                rotate = true;
            }

        }
        else if(transform.position.x > 0 && transform.position.y < 0)//右下
        {
            ChangeRightToLeft();//左向きの絵
            if (rotate == false)
            {
                transform.Rotate(new Vector3(0, 0, angle));
                rotate = true;
            }

        }
        trand = Random.Range(6, 13);


    }

    float GetAngle(Vector2 start, Vector2 target)//角度の取得
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }

    void ChangeLeftToRight()
    {
        // SpriteRenderのspriteを設定済みの他のspriteに変更
        MainSpriteRenderer.sprite = rightSprite;
    }

    void ChangeRightToLeft()
    {
        // SpriteRenderのspriteを設定済みの他のspriteに変更
        MainSpriteRenderer.sprite = leftSprite;
    }
}
