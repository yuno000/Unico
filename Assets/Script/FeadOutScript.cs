using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeadOutScript : MonoBehaviour
{
    public static FeadOutScript instance;
    public static bool start;
    float alfa;
    float speed = 0.005f;
    float red, green, blue;

    void Start()
    {
        start = false;
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;
        Debug.Log(alfa);
    }

    void Update()
    {
        if (start == true)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
            Debug.Log(alfa);
        }
    }
}
