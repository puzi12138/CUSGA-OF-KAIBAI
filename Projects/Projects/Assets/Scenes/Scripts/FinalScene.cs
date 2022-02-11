using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{
    public Animator anim;
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
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
                if (index == 1)
                {
                    GameObject.Find("Dialogs/Canvas01/Panel/Leader").SetActive(true);
                }
                if (index == 4)
                {
                    anim.SetTrigger("Leader");
                }
            }
            else if (!textFinished)
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

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        text.text = "";
        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length - 1)
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
