using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGenerater : MonoBehaviour {

    public GameObject enemy; //敵のオブジェクト
    public float interval = 3; //何秒に一回敵を発生させるか
    float timer = 0; //タイマー

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //プレイヤーのHPが０になったら生成しない
       // if (GameObject.Find("Player").GetComponent<GameScript>().playerHP > 0)
        {
            timer -= Time.deltaTime; //タイマーを減らす
            if (timer < 0)
            {
                //タイマーがゼロより小さくなったら
                Spawn(); // Spawnメソッドを呼ぶ
                timer = interval; // タイマーをリセットする

            }

        }
    }
    // 敵を生成するメソッド
    void Spawn()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
