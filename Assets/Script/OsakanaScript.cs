using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*敵（魚）のスクリプト
 * △魚の動き2秒で往復
 * 魚のHP
 * 魚とげにあたったらきえる
 * △魚のRush:6秒放置したら（0,0,0）へ
 * ★魚の向き
 */

public class OsakanaScript : MonoBehaviour {

    public int osakanaHP = 1;
    private int timer;
    public GameObject osakana;
    //public GameObject osakanamigi;
    public GameObject gameManagement;
    public GameObject uni;
    public float muki;
    private int speed;
    private float initiateposx;
    private float initiateposy;
    private float t;
    private bool rotate;

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
    }

	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;

       if(t <= 6)
        {
            OsakanaMoov();
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
        }
    }

    void Damageosakana()
    {
        osakanaHP--;
        if(osakanaHP <= 0)
        {
            Destroy(this.gameObject);
            GameManagement.instance.score += 100;//sakanaを倒すとスコア+100
            Debug.Log(GameManagement.instance.score);

        }
    }

    void OsakanaMoov()
    {
        float T = 3.0f;
        float f = 1.0f / T;
        muki = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * f * Time.time));//周期Tでー１と１を繰り返す
        if (muki > 0)
        {
            osakana.transform.position += new Vector3(0.02f, 0,0);
            //osakanamigi.transform.position += new Vector3(0.02f,0,0);
            //osakanamigi.gameObject.SetActive(false);//右向きの絵OFF
            //osakana.gameObject.SetActive(true);//左向きの絵ON
        }
        else if(muki <= 0)
        {
            osakana.transform.position -= new Vector3(0.02f, 0,0);
            //osakanamigi.transform.position -= new Vector3(0.02f, 0, 0);
            //osakanamigi.gameObject.SetActive(true);//右向けの絵ON
            //sakana.gameObject.SetActive(false);//左向きの絵OFF
        }

    }



    void OsakanaRush()
    {
        speed = 3;
        float angle = GetAngle(_start.transform.position, _target.transform.position);//角度の取得
        Debug.Log(angle);

        transform.position = Vector3.MoveTowards(transform.position, new Vector2(-0.25f,0.8f), speed * Time.deltaTime);//真ん中に向かう

        //float dx = uni.transform.position.x - uni.transform.position.x;
        //float dy = osakana.transform.position.y - osakana.transform.position.x;
        //float rad = Mathf.Atan2(dy, dx);

        if (transform.position.x <= -0.25f && transform.position.y >= 0.8f)//画面左上
        {
            if (rotate == false)
            {
                transform.Rotate(new Vector3(0, 0, angle - 180));
                rotate = true;
            }
            //右向きの絵

        }else if(transform.position.x < -0.25f && transform.position.y < 0.8f)//左下
        {
            if (rotate == false)
            {
                transform.Rotate(new Vector3(0, 0, 180 + angle));
                rotate = true;
            }
            //右向きの絵

        }else if(transform.position.x > -0.25f && transform.position.y > 0.8f)//右上
        {
            if (rotate == false)
            {
                transform.Rotate(new Vector3(0, 0, angle));
                rotate = true;
            }
            //左向きの絵

        }
        else if(transform.position.x > -0.25f && transform.position.y < 0.8f)//右下
        {
            if (rotate == false)
            {
                transform.Rotate(new Vector3(0, 0, angle));
                rotate = true;
            }
            //左向きの絵

        }


    }

    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }
}
