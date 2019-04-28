using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameScripts : MonoBehaviour {

    public GameObject[] toge;
    public GameObject test;



    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (OnTouchDown())
        {
            Debug.Log("タップされました");

        }
    }



    bool OnTouchDown()
    {
        
        // タッチされているとき
        if (0 < Input.touchCount)
        {
            // タッチされている指の数だけ処理
            for (int i = 0; i < Input.touchCount; i++)
            {
                Debug.Log(Input.touchCount);
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチしたときかどうか
                if (t.phase == TouchPhase.Began)
                {

                    Vector3 pos = Camera.main.ScreenToWorldPoint(t.position);
                    Vector3 cons = new Vector3(pos.x,pos.y,0);
                    Instantiate(test,cons,Quaternion.identity);
                    Debug.Log(t.position);
                    //タッチした位置からRayを飛ばす
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(hit.transform.position);
                        //Rayを飛ばしてあたったオブジェクトが自分自身だったら
                        if (hit.collider.gameObject == this.gameObject)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false; //タッチされてなかったらfalse
    }

}
