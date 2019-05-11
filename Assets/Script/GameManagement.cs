using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*日にちの管理
 * スコアの管理
 *セーブとロード 
 * 魚のランダム生成
 */

public class GameManagement : MonoBehaviour {
    public Text dayLabel;
    public int  day;
    private int t;
    public int score;
    public Text scoreLabel;
    private bool onetime;


    

	// Use this for initialization
	void Start () {
        day = PlayerPrefs.GetInt("Day", day);
        if (day == 0)
        {
            day = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        t++;
        scoreLabel.text = "Score:" + score.ToString();
        dayLabel.text = "Day" + day.ToString();
        Debug.Log(t);

        if (t > 10.0f && GetComponent<UniScript>().uniHP > 0)
        {
            SceneManager.LoadScene("DayChange");
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Day", day);
        PlayerPrefs.Save();
    }


}
