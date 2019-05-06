using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsakanaScript : MonoBehaviour {

    public int osakanaHP = 1;
    public int osakanaCount;
    public Text osakanaCountLabel;
    public GameObject osakana;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    void Damageosakana()
    {
        osakanaHP--;
        if(osakanaHP <= 0)
        {
            Destroy(osakana);
            osakanaCount++;

        }
    }

    void osakanaRush()
    {
       // if ()
        {

        }
    }
}
