using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*スタートボタンを押すと
 * ゲームスタートシーンへの遷移
 */

public class GameoverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RetryButton()
    {
        SceneManager.LoadScene("Start");
    }
}
