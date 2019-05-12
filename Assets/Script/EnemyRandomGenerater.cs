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
    private int randomKind;//魚の種類を決める数
    private int interval; //何秒に一回敵を発生させるか(ランダムでr秒）
    private float initiatePosx;
    private float initiatePosy;
    private bool range;
    private Ray judgerange;
    private RaycastHit hit;
    public float timer;//タイマー

    // Use this for initialization
    void Start () {
        interval = 3;
        timer = interval;

    }

    // Update is called once per frame
    void Update () {
        Debug.Log(timer);
        //プレイヤーのHPが０になったら生成しない
       // if (GameObject.Find("Player").GetComponent<GameScript>().playerHP > 0)
        {
            timer -= Time.deltaTime; //タイマーを減らす
            if (timer < 0)
            {
                Debug.Log(timer);
                //タイマーがゼロより小さくなったら
                OsakanaInitiate(); // OsakanaInitiateメソッドを呼ぶ
                timer = interval; // タイマーをリセットする

            }

        }
    }
    // 敵を生成するメソッド
    void OsakanaInitiate()
    {
        Debug.Log("osakanainitiate");
        interval = Random.Range(1, 3);//間隔を1～3でランダムしなおす
        timer = interval;
        randomKind = Random.Range(0, 2);//種類を０～2でランダムしなおす

        initiatePosx = Random.Range(-8.25f, 7.75f);//x位置を-8.25～7.75でランダムしなおす
        initiatePosy = Random.Range(-3.7f, 5.3f);//y位置を-3.7～5.3でランダムしなおす
        Vector2 r = new Vector3(initiatePosx, initiatePosy, 0);//ランダムで出した生成位置


        while (r.x <= 2.5 && r.x >= -2.75 && r.y <= 3.15 && r.y >= 1.55)
        {
            initiatePosx = Random.Range(-8.25f, 7.75f);//x位置を-8.25～7.75でランダムしなおす
            initiatePosy = Random.Range(-3.7f, 5.3f);//y位置を-3.7～5.3でランダムしなおす
        }

        Instantiate(osakanakinds[randomKind], new Vector2(initiatePosx, initiatePosy), Quaternion.identity);

        //while (hit.collider.tag != "range")
        //{
        //    initiatePosx = Random.Range(-8.25f, 7.75f);//x位置を-8.25～7.75でランダムしなおす
        //    initiatePosy = Random.Range(-3.7f, 5.3f);//y位置を-3.7～5.3でランダムしなおす
        //    Vector2 r = new Vector3(initiatePosx, initiatePosy,0);//rにrayの出発地点を入れる
        //    judgerange = new Ray(r, new Vector3(initiatePosx, initiatePosy,5));//ｒからｚ座標に＋５したところにrayをとばす

        //}



    }
}
