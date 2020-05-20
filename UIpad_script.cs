using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIpad_script : MonoBehaviour{

    data color_touch;
    int screen_w = Screen.width;
    int i=0,touchcount=0;
    Vector2 t_d;
    GameObject drag_s;
    GameObject cube;
    bool touch;
    void Start()
    {
        cube = GameObject.Find("Cube");
        color_touch = GameObject.Find("data_manager").GetComponent<data>();
        drag_s = GameObject.Find("Canvas").transform.Find("Image").transform.GetChild(0).gameObject;
    }
    
	public void OnBeginDrag()//터치한 좌표에 맞춰 막대기 생성및 공이동
    {
        touchcount++;
        if (touch == false)
        {
            touch = true;
            t_d = Input.mousePosition;
            drag_s.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(t_d.x/(screen_w/720)- 360, -6.5f);
            Check_po(t_d);
            drag_s.SetActive(true);
            Debug.Log(drag_s.transform.GetComponent<RectTransform>().anchoredPosition.x);
            Debug.Log(t_d.x - (screen_w * 0.5f));
            Debug.Log(t_d.x);
            Debug.Log(screen_w);
        }
        
    }
    public void OnDrag()//터치한 좌표에 맞춰 공,막대기 이동
    {
        touch = true;
        t_d = Input.mousePosition;
        drag_s.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(t_d.x / (screen_w / 720) - 360, -6.5f);
        Check_po(t_d);
    }
    public void OnEndDrag()//막대기 사라지기 및 공 멈추기
    {
        touch = false;
        drag_s.SetActive(false);
    }

    void Check_po(Vector2 t_d)
    {
       
        cube.transform.position = new Vector3(1.5f+((t_d.x / (screen_w / 720) - 360)* 0.026f), cube.transform.position.y, cube.transform.position.z);
    }

}
