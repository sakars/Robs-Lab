using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class receptionist : MonoBehaviour
{
    // Start is called before the first frame update
    public static int reputation_score;
    public static receptionist self;
    public GameObject WaitingRoom;
    public GameObject patientsLeft;
    public GameObject reputation;
    public GameObject winhlerk;
    public GameObject loshlerk;
    public GameObject winstarer;
    public float endscore = 0;
    void Start()
    {
        self = this;
        reputation_score = 75;
        winhlerk.SetActive(false);
        loshlerk.SetActive(false);
        //InvokeRepeating("LowerScore", 5.0f, 5.0f);
    }
    void LowerScore()
    {
        reputation_score--;
        reputation.GetComponent<Text>().text = reputation_score + "%";
        if (reputation_score < 20)
        {
            lose();
        }
    }
    // Update is called once per frame
    public void Test()
    {
        if(transform.GetChild(0).childCount==0 && transform.GetChild(1).childCount == 0 && transform.GetChild(2).childCount == 0)
        {
            Debug.Log("reset");
            if (WaitingRoom.transform.childCount == 0)
            {
                win();
            }
            else
            {
                for (int i = 0; i < 3 && WaitingRoom.transform.childCount != 0; i++)
                {
                    Transform ob = WaitingRoom.transform.GetChild(0);
                    ob.SetParent(transform.GetChild(i));
                    ob.localPosition = Vector2.zero;
                    ob.GetComponent<Image>().SetNativeSize();
                    ob.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    ob.GetComponent<BoxCollider2D>().size = ob.transform.GetComponent<RectTransform>().rect.size;
                }
                if (WaitingRoom.transform.childCount%10 != 1 || WaitingRoom.transform.childCount % 100 == 11)
                {
                    patientsLeft.GetComponent<Text>().text = WaitingRoom.transform.childCount.ToString() + " patients";
                }
                else
                {
                    patientsLeft.GetComponent<Text>().text = WaitingRoom.transform.childCount.ToString() + " patient";
                }
            }
        }
    }
    public void displayScore()
    {
        reputation.GetComponent<Text>().text = reputation_score + "%";
    }
    public void win()
    {
        CancelInvoke();
        if (PlayerPrefs.GetInt("Clevel") != 5)
        {
            PlayerPrefs.SetInt("Lvl" + (PlayerPrefs.GetInt("Clevel") + 1).ToString(), 1);
        }
        winhlerk.SetActive(true);
        endscore = reputation_score * 50;
        foreach(var colb in UIInp.instances)
        {
            if (colb) endscore += colb.fill;
        }
        GameObject.Find("ScoringSyst").GetComponent<Text>().text = "Score: " + Mathf.RoundToInt(endscore/4);
        
        for (int i = 1; i < 4; i++)
        {
            winstarer.transform.GetChild(i - 1).GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            if (endscore > Mathf.Sqrt(i + 1) * 500)
            {
                winstarer.transform.GetChild(i-1).GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }
            else
            {
                break;
            }
        }
    }
    public void lose()
    {
        CancelInvoke();
        //loshlerk.GetChild(2).GetComponent<Script>().text
        loshlerk.SetActive(true);
    }
    public void didLose()
    {
        bool lost = true;
        foreach(var sc in UIInp.instances)
        {
            if (sc) lost = false;
        }
        if (lost) lose();
    }
}
