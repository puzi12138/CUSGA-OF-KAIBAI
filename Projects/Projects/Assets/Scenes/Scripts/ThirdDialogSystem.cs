using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//第三章对话框系统
public class ThirdDialogSystem : MonoBehaviour
{
    [Header("UI组件")]//标记分类
    public Text text;//Text组件

    [Header("文本文件")]
    public TextAsset textFile;//文本文件
    public int index;//标记文件中的行数
    public float textSpeed;//控制文字输出速度

    bool textFinished;//标记某行文字是否读取完
    bool cancelTyping;//标记用以快速显示文字

    List<string> textList = new List<string>();//定义列表存储文本文件各行内容
    // Start is called before the first frame update
    void Awake()
    {
        GetTextFromFile(textFile);//在其余函数开始调用前便获取文本文件
    }
    private void OnEnable()//在对话框启用时便输出第一句话
    {
        textFinished = true;
        StartCoroutine(SetTextUI());//协程处理
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && index == textList.Count)
        {
            gameObject.SetActive(false);//在结束对话后将对话框关闭
            index = 0;//结束对话后将标记行数清零
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (textFinished && !cancelTyping)//若文件正在输出且未取消输出则继续执行
            {
                StartCoroutine(SetTextUI());//执行协程处理
                if (index == 3)//控制物体开启
                {
                    GameObject.Find("Dialogs/Canvas01/Panel/MainPlayer").SetActive(true);
                    GameObject.Find("Dialogs/Canvas01/Panel/Chief").SetActive(true);
                }
                if (index == 4)//控制物体关闭
                {
                    GameObject.Find("Dialogs/Canvas01/Panel/MainPlayer").SetActive(false);
                }
            }
            else if (!textFinished)//每按下一次按键，canceTyping的值对调
            {
                cancelTyping = !cancelTyping;
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');//以换行符为标记点使得文本逐行输出

        foreach (var line in lineData)
        {
            textList.Add(line);//逐行输出
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;//输出前标记为否
        text.text = "";//每次调用前将先前的文字清空
        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length - 1)//未取消输入则执行
        {
            text.text += textList[index][letter];//获得该行文字的第letter个字符
            letter++;
            yield return new WaitForSeconds(textSpeed);//在执行下一次前等待时间
        }
        text.text = textList[index];//若上述循环不执行则直接输出全部文本
        cancelTyping = false;//输出完后将其标记为假，表示下一行未取消输入
        textFinished = true;//输出后标记为真
        index++;
    }
}
