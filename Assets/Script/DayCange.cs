using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCange : MonoBehaviour {
    /*次の日のロード
     * 日付の更新
     */

    public GameObject gameManagement;
    private float timer;
    
    
    // Use this for initialization
    void Start()
    {
        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;
        // シーンの読み込み
        SceneManager.LoadScene("Main");
        timer = 0;
    }

    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        Debug.Log(nextScene.name);
        Debug.Log(mode);

        gameManagement.GetComponent<GameManagement>().day += 1;
        PlayerPrefs.SetInt("Score", gameManagement.GetComponent<GameManagement>().day);
        PlayerPrefs.SetInt("Day", gameManagement.GetComponent<GameManagement>().score);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            SceneManager.LoadScene("Main");

        }

	}



}
