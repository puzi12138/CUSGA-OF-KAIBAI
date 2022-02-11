using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//加在非序幕之外的每个场景前，作为动画淡出效果
public class Before01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Open",1.5f);//调用Open函数并等待1.5秒
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        GameObject ParentObject = GameObject.Find("Dialogs");//找到父物体
        GameObject ChildObject = ParentObject.transform.Find("Canvas01").gameObject;//找到父物体下隐藏的子物体
        ChildObject.SetActive(true);//将子物体变为显示状态
        //下同上
        GameObject ParentObject1 = GameObject.Find("Player");
        GameObject ChildObject1 = ParentObject1.transform.Find("Player01").gameObject;
        ChildObject1.SetActive(true);
    }
}
