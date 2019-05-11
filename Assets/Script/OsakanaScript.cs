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
    public GameObject gameManagement;
    public GameObject uni;
    public Vector2 muki;
    public int speed;
    private float initiateposx;
    private float initiateposy;
    private int frame;
    private int frame2;
    private float t;



    // Use this for initialization
    void Start () {
        initiateposx = this.gameObject.transform.position.x;
        initiateposy = this.gameObject.transform.position.y;
        frame = 0;
        frame2 = 0;
        t = 0;
	}
	
	// Update is called once per frame
	void Update () {
       frame++;
        t += Time.deltaTime;

       if(frame <= 6/Time.deltaTime)
        {
            frame2++;
            OsakanaMoov();
        }
        else if(frame > 6/Time.deltaTime)//突撃
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
            Destroy(osakana);
            gameManagement.GetComponent<GameManagement>().score += 100;//sakanaを倒すとスコア+100 

        }
    }

    void OsakanaMoov()
    {
        //if (initiateposy > 0)//左を向いてるとき
        //{
            if (frame2 <= 2/Time.deltaTime)//2秒左に動く
            {
            transform.position -= new Vector3(0.02f, 0,0);

            Debug.Log("最初の左");
        }
        else if(frame2 > 2/Time.deltaTime )
            {
            Debug.Log("次の右");
                //transform.Rotate(new Vector2(0, 360);
                transform.position += new Vector3(0.02f, 0, 0);
            frame2 = 0;
            }

        //}
        //else//右を向いているとき
        //{

        //}
    }



    void OsakanaRush()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(-0.25f,0.8f), speed * Time.deltaTime);

    }
}
