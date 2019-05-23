using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*スタートボタンを押すと
 * ゲームスタートシーンへの遷移
 * 日数が０に戻る
 */

public class GameoverScript : MonoBehaviour {
    public GameObject retryEffect;
    public Text bestdayLabel;
    public Text bestscoreLabel;
    private bool one;
    // Use this for initialization

    void Start () {
        one = false;

        PlayerPrefs.GetInt("BestDay", GameManagement.bestday);
        PlayerPrefs.GetInt("BestScore", GameManagement.bestscore);

        if (GameManagement.bestday  < GameManagement.day)
        {
            GameManagement.bestday = GameManagement.day;
        }
        if (GameManagement.bestscore < GameManagement.score)
        {
            GameManagement.bestscore = GameManagement.score;
        }

        PlayerPrefs.SetInt("BestDay", GameManagement.bestday);
        PlayerPrefs.SetInt("BestScore", GameManagement.bestscore);
        PlayerPrefs.Save();

        bestdayLabel.text = "BestDay:  Day" + GameManagement.bestday;
        bestscoreLabel.text = "BestScore:" + GameManagement.bestscore;

    }
	
	// Update is called once per frame
	void Update () {
        if(one == false)
        {
            GameManagement.day = 1;
            GameManagement.score = 0;

            one = true;
        }
       

    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Start");
        PlayerPrefs.SetInt("Score", GameManagement.score);
        PlayerPrefs.SetInt("Day", GameManagement.day);
        PlayerPrefs.Save();

    }
}
