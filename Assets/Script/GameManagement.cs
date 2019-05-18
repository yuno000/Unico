using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*日にちの管理
 *クリア
 *★スコアの管理
 *★セーブとロード 
 * 魚のランダム生成
 * 音楽の再生
 */

public class GameManagement : MonoBehaviour {
    public static GameManagement instance;
    public Text dayLabel;
    public static int  day;
    public static int bestday;
    public static int bestsxore;
    private float t;
    public static int score;
    public Text scoreLabel;
    private bool onetime;
    public GameObject uni;
    //AudioSource audioSource;
    //public AudioClip bgm1;


    

	// Use this for initialization
	void Start () {
        //audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.clip = bgm1;
        //audioSource.Play();

        day = PlayerPrefs.GetInt("Day", day);
        if (day == 0)
        {
            day = 1;
            t = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        scoreLabel.text = "Score:" + score.ToString();
        dayLabel.text = "Day" + day.ToString();
        

        if (t > 60.0f && uni.GetComponent<UniScript>().uniHP > 0)
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
