using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {
    public float speed=0;
    public GameObject a,cr;
    public Transform tr;
    public AudioClip sound;
    public AudioSource bounce=null;
    GameObject UI_button;
    float cubeht;
    float ht = 0;
    float gravity = 0.1f;
    data scale;
    void Start()//초기설정
    {
        UI_button = GameObject.Find("Canvas").transform.Find("pause").gameObject;
        scale = GameObject.Find("data_manager").GetComponent<data>();
        cr = GameObject.Find("Main Camera");
        bounce = this.GetComponent<AudioSource>();
        tr=this.GetComponent<Transform>();
        tr.localScale = new Vector3(2, 2, 2);
        StartCoroutine("Wait");
        ht = tr.position.y;
        if (D_Option.Sound == true)
            bounce.mute = false;
        else
            bounce.mute = true;
    }
    IEnumerator Wait()//일정시간이 지날수록 낙하속도 증가
    {
        if (gravity < 0.75f) { 
            gravity = 0.25f+(0.005f * (scale.score));
        }
        transform.Translate(0, 0, gravity);
        if (ht > tr.position.y)
            cr.GetComponent<cr>().Movecr();
        if (Input.GetKeyDown(KeyCode.Escape))
            GameObject.Find("Canvas").transform.Find("pause").GetComponent<UI_Button>().T_time();
        yield return new WaitForSeconds(0.02f);
        StartCoroutine("Wait");
    }
    IEnumerator j_wait()
    {
        yield return new WaitForSeconds(0.01f);
    }
}
