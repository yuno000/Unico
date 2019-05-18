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
    // Use this for initialization

    private void Awake()
    {
        PlayerPrefs.SetInt("BestDay", GameManagement.bestday);
        if (GameManagement.bestday > GameManagement.day)
        {
            GameManagement.bestday = GameManagement.day;
        }
    }

    void Start () {
        bestscoreText.text = "MaxDay:" + GameManagement.bestday;
        GameManagement.day = 1;
        GameManagement.score = 0;
    }
	
	// Update is called once per frame
	void Update () {
       

    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Start");
        PlayerPrefs.SetInt("Score", GameManagement.score);
        PlayerPrefs.SetInt("Day", GameManagement.day);
        PlayerPrefs.Save();

    }
}
