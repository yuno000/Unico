using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*敵（魚）のスクリプト
 * 魚のHP
 * 魚とげにあたったらきえる
 * 魚のRush:3秒放置したら（0,0,0）へ
 * 
 */

public class OsakanaScript : MonoBehaviour {

    public int osakanaHP = 1;
    private int timer;
    public GameObject osakana;
    public int frame;

	// Use this for initialization
	void Start () {
        frame = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
       frame++;
       if(frame > 3 / Time.deltaTime)
        {
            osakanaRush();
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "toge")
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
            gameObject.GetComponent<GameManager>().score += 100;//sakanaを倒すとスコア+100 

        }
    }



    void osakanaRush()
    {
        
    }
}
