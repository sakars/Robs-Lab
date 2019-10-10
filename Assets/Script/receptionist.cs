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
    void Start()
    {
        self = this;
        reputation_score = 75;
        //InvokeRepeating("LowerScore", 5.0f, 5.0f);
    }
    void LowerScore()
    {
        reputation_score--;
        reputation.GetComponent<Text>().text = reputation_score + "%";
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
    public void win()
    {
        Debug.Log("You win!!!");
    }
}
