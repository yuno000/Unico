using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeadInScript : MonoBehaviour {

    float alfa;
    float speed = 0.005f;
    float red, green, blue;

    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;
        Debug.Log(alfa);
    }

    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa -= speed;
    }
}
