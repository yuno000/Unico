using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGenerater : MonoBehaviour {

    /*★敵のランダム生成
     * ・位置
     * ・ゲームオブジェクトの種類
     * ・時間
     * ・向き（左右）
     */


    public GameObject[] osakanakinds = new GameObject[3];//ゲームオブジェクトの種類
    private int rondomKind;//魚の種類を決める数
    private int interval; //何秒に一回敵を発生させるか(ランダムでr秒）
    private float initiatePosx;
    private float initiatePosy;
    private bool range;
    private Ray judgerange;
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
                OsakanaInitiate(); // Spawnメソッドを呼ぶ
                timer = interval; // タイマーをリセットする

            }

        }
    }
    // 敵を生成するメソッド
    void OsakanaInitiate()
    {
        Instantiate(osakanakinds[rondomKind],new Vector2(initiatePosx, initiatePosy),Quaternion.identity);
        interval = Random.Range(1, 3);//間隔を1～3でランダムしなおす
        rondomKind = Random.Range(0, 2);//種類を０～2でランダムしなおす
        while ()
        {
            initiatePosx = Random.Range(-8.25f, 7.75f);//x位置を-8.25～7.75でランダムしなおす
            initiatePosy = Random.Range(-3.7f, 5.3f);//y位置を-3.7～5.3でランダムしなおす
            Vector2 r = new Vector3(initiatePosx, initiatePosy,0);
            judgerange = new Ray(r, new Vector3(initiatePosx, initiatePosy,5));
        }


    }
}
