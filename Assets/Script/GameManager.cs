using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*日にちの管理
 * スコアの管理
 *セーブとロード 
 */

public class GameManager : MonoBehaviour {
    public Text dayLabel;
    public int  day;
    private int frame;
    public int score;
    public Text scoreLabel;
    

	// Use this for initialization
	void Start () {
        day = 1;
        
	}
	
	// Update is called once per frame
	void Update () {
        scoreLabel.text = "Score:" + score.ToString();
        dayLabel.text = "Day" + day.ToString();

        if (frame > 60 / Time.deltaTime && GetComponent<UniScript>().uniHP > 0)
        {
            SceneManager.LoadScene("DayChange");
        }
    }


    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.SetFloat("Day", day);
        PlayerPrefs.Save();
    }
}
