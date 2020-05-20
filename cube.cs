using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cube : MonoBehaviour
{
    data data_tr;
    cr noob;
    score Tt;
    int loading;
    public int idx;
    int m_d;
    bool timedata;
    AudioSource play;
    GameObject ani;
    void Start()//초기세팅
    {
        data_tr = GameObject.Find("data_manager").GetComponent<data>();
        noob = GameObject.Find("Main Camera").GetComponent<cr>();
        Tt = GameObject.Find("Canvas").transform.Find("Text").GetComponent<score>();
        ani = Resources.Load<GameObject>("prefab/Cube_Particle");
        play = this.GetComponent<AudioSource>();
        m_d = D_Option.Mode_data;
        if (D_Option.Sound == true)
            play.mute = false;
        else
            play.mute = true;
    }
    void OnTriggerEnter(Collider coll)//공에 닿으면 자신의 오브젝트위치에따라 소리내고 밑으로가기
    {
        if (coll.transform.tag == "Cube")
        {
            if (D_Option.c_ld == 0)
            {
                D_Option.c_ld = 1;
                play.PlayOneShot(data_tr.bounce[idx], 0.5f);
                Instantiate(ani, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), ani.transform.rotation);
                this.transform.Translate(0, -54, 0);
                noob.count_barrier--;
                timedata = GameObject.Find("Canvas").transform.Find("pause").GetComponent<UI_Button>().sw_cl;
                    if (timedata == true)
                    {
                        GameObject.Find("Canvas").transform.Find("pause").GetComponent<UI_Button>().sw_cl = false;
                    }
                    data_tr.score += 1;
                idx = Random.Range(0, 7);
                this.transform.position = new Vector3(-5.3f + (0.675f * ((idx) * 2 - 1)), this.transform.position.y, this.transform.position.z);//박스이동
                Tt.Dis_sc(data_tr.score);
                data_tr.combo++;
                D_Option.c_ld = 0;
            }
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("pause").GetComponent<UI_Button>().GameOver();
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
