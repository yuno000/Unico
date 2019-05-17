using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayCange : MonoBehaviour {
    /* 次の日のロード
     * 日付の更新
     */
     
    private float timer;
    public Text dayChangeLabel;



    // Use this for initialization
    void Start()
    {
        int day = GameManagement.day;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        dayChangeLabel.text = "Day" + GameManagement.day.ToString() + "→ Day" + (GameManagement.day+1).ToString();
        Debug.Log(GameManagement.day);

	}

    public void OnNextButton()
    {
        SceneManager.LoadScene("Main");

        PlayerPrefs.SetInt("Score", GameManagement.score);
        PlayerPrefs.SetInt("Day", GameManagement.day);
        PlayerPrefs.Save();
    }

}
