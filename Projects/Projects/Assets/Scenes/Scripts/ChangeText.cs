using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Button btn;
    public Text text;
    public bool flag=true;

    public void Change01()
    {
        btn = GameObject.Find("Button").GetComponent<Button>();
        Text text = GameObject.Find("Text").GetComponent<Text>();
        text.text = "∫√“Æ£°";
    }

}
