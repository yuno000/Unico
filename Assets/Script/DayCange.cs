using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayCange : MonoBehaviour {
    /*次の日のロード
     * 日付の更新
     */
     
    private float timer;
    public Text dayChangeLabel;
    int day;


    // Use this for initialization
    void Start()
    {
        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;
        // シーンの読み込み
        SceneManager.LoadScene("Main");
        timer = 0;
        int day = GameManagement.day;
    }

    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        Debug.Log(nextScene.name);
        Debug.Log(mode);

       GameManagement.day += 1;
        PlayerPrefs.SetInt("Score", GameManagement.day);
        PlayerPrefs.SetInt("Day",GameManagement.score);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        dayChangeLabel.text = day +"→" + (day+1);

        if(timer > 5)
        {
            SceneManager.LoadScene("Main");

        }

	}



}
