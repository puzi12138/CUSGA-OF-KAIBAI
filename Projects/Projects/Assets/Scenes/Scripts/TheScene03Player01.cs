using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//非序幕主角控制代码
public class TheScene03Player01 : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        GameObject obj = GameObject.Find("Dialogs/Canvas01/Panel");//找到对话框系统
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Player01");///执行角色淡入操作
        }
        else if (!obj.gameObject.activeInHierarchy)//当对话框系统关闭后执行启动下一幕操作，防误触
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("Player02");//执行淡出动画
                Invoke("Final", 1.5f);
            }         
        }
    }

    public void Final()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//加载至下一个场景
    }
}
