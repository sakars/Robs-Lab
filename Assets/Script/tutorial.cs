using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public int farth;
    public GameObject tg;
    public GameObject theotherman;
    void Start()
    {
        //if(PlayerPrefs.GetInt("Tut") == 0)
        //{
            farth = 0;
            tg = GameObject.Find("TutorialGuys");
            tg.SetActive(true);
            part1();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void part1()
    {
        farth++;
        switch (farth) {
            case 2:
                simple(1);
                break;
            case 3:
                simple(1);
                break;
            case 4:
                simple(2);
                break;
            case 5:
                simple(3);
                break;
            case 6:
                theotherman.GetComponent<swiper>().forcePagrabs();
                simple(2);
                break;
            case 7:
                simple(4);
                break;
            case 8:
                simple(4);
                break;
            case 9:
                simple(1);
                break;
            case 10:
                theotherman.GetComponent<swiper>().forceTelpa();
                simple(4);
                break;
            case 11:
                simple(1);
                break;
            case 12:
                simple(3);
                break;
            case 13:
                simple(1);
                break;
            case 14:
                simple(1);
                break;
            case 15:
                simple(2);
                break;
            case 16:
                simple(2);
                //PlayerPrefs.SetInt("Tut", 1);
                break;
        }
    }

    void simple(int index)
    {
        for(int i = 1; i < 5; i++)
        {
            tg.transform.GetChild(i).gameObject.SetActive(false);
        }
        tg.transform.GetChild(index).gameObject.SetActive(true);
        tg.transform.GetChild(index).GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/tutorialrobs/tt_" + farth.ToString());
    }

    public void Advance()
    {
        if(farth < 16)
        {
            part1();
        }
        else
        {
            tg.SetActive(false);
        }
    }
}
