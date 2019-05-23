using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeunicoScript : MonoBehaviour {
    
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite holdSprite;
    public Sprite damageSprite;

    // Use this for initialization
    void Start () {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (GameManagement.day % 10 == 0)
        {
            MainSpriteRenderer.gameObject.transform.localScale *= (1 + (GameManagement.day*0.01f));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeHoldToDamage()
    {
        // SpriteRenderのspriteを設定済みの他のspriteに変更
        MainSpriteRenderer.sprite = damageSprite;
    }

    public void ChangeDamageToHold()
    {
        // SpriteRenderのspriteを設定済みの他のspriteに変更
        MainSpriteRenderer.sprite = holdSprite;
    }
}
