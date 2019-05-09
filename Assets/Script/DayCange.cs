using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCange : MonoBehaviour {
    /*次の日のロード
     * 日付の更新
     */

    public int day;
    public int score;
    
    
    // Use this for initialization
    void Start()
    {
        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;
        // シーンの読み込み
        SceneManager.LoadScene("Main");
    }

    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        Debug.Log(nextScene.name);
        Debug.Log(mode);

        day += 1;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Day", day);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update () {
		
	}



}
