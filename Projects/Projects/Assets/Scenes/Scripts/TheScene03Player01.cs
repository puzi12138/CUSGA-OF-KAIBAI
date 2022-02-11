using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheScene03Player01 : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        GameObject obj = GameObject.Find("Dialogs/Canvas01/Panel");
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Player01");
        }
        else if (!obj.gameObject.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("Player02");
                Invoke("Final", 1.5f);
            }         
        }
    }

    public void Final()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
