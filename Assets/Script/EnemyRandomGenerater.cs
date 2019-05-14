﻿using System.Collections;
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
    private float initiatePosx;//生成位置ｘ
    private float initiatePosy;//生成位置ｙ
    private bool range;
    private Ray judgerange;
    private RaycastHit hit;
    public GameObject osakanaprefab;
    public float timer;//タイマー

    // Use this for initialization
    void Start () {
        interval = 3;
        timer = interval;
        osakanaprefab = null;

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
                OsakanaInitiate(); // OsakanaInitiateメソッドを呼ぶ
                timer = interval; // タイマーをリセットする

            }

        }
    }
    // 敵を生成するメソッド
    void OsakanaInitiate()
    {
        Debug.Log("osakanainitiate");
        interval = Random.Range(1, 4);//間隔を1～3でランダムしなおす
        Debug.Log(randomKind);
        timer = interval;
        randomKind = Random.Range(0, 3);//種類を０～2でランダムしなおす

        initiatePosx = Random.Range(-8.25f, 7.75f);//x位置を-8.25～7.75でランダムしなおす
        initiatePosy = Random.Range(-3.7f, 5.3f);//y位置を-3.7～5.3でランダムしなおす
        Vector3 r = new Vector3(initiatePosx, initiatePosy, 0);//ランダムで出した生成位置


        while (r.x <= 2.5 && r.x >= -2.75 && r.y <= 3.15 && r.y >= 1.55)//生成しちゃダメな範囲なら繰り返す
        {
            initiatePosx = Random.Range(-8.25f, 7.75f);//x位置を-8.25～7.75でランダムしなおす
            initiatePosy = Random.Range(-3.7f, 5.3f);//y位置を-3.7～5.3でランダムしなおす
            r = new Vector3(initiatePosx, initiatePosy, 0);
        }

        GameObject oaskanaprefab = Instantiate(osakanakinds[randomKind], new Vector2(initiatePosx, initiatePosy), Quaternion.identity) as GameObject;//生成していい範囲で生成

        //while (hit.collider.tag != "range")
        //{
        //    initiatePosx = Random.Range(-8.25f, 7.75f);//x位置を-8.25～7.75でランダムしなおす
        //    initiatePosy = Random.Range(-3.7f, 5.3f);//y位置を-3.7～5.3でランダムしなおす
        //    Vector2 r = new Vector3(initiatePosx, initiatePosy,0);//rにrayの出発地点を入れる
        //    judgerange = new Ray(r, new Vector3(initiatePosx, initiatePosy,5));//ｒからｚ座標に＋５したところにrayをとばす

        //}



    }
}
