using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public Text text;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    bool textFinished;
    bool cancelTyping;

    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        GetTextFromFile(textFile);
    }
    private void OnEnable()
    {
        //text.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0)) && index==textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
                if (index == 3)
                {
                    GameObject.Find("Canvas/Panel/MainPlayer").SetActive(true);
                }
                if(index==4)
                {
                    GameObject.Find("Canvas/Panel/MainPlayer").SetActive(false);
                }
            }
            else if(!textFinished)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach(var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        text.text = "";
        //for(int i=0;i<textList[index].Length;i++)
        //{
        //    text.text += textList[index][i];

        //    yield return new WaitForSeconds(textSpeed);
        //}
        int letter = 0;
        while(!cancelTyping&&letter<textList[index].Length-1)
        {
            text.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        text.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }
}
