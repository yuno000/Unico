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
    public Text bestscoreText;
    private bool one;
    // Use this for initialization

    void Start () {
        one = false;
        PlayerPrefs.SetInt("BestDay", GameManagement.bestday);
        if (GameManagement.bestday > GameManagement.day)
        {
            GameManagement.bestday = GameManagement.day;
        }

        bestscoreText.text = "MaxDay:" + GameManagement.bestday;

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
