using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class receptionist : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WaitingRoom;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Test()
    {
        if(transform.GetChild(0).childCount==0 && transform.GetChild(1).childCount == 0 && transform.GetChild(2).childCount == 0)
        {
            Debug.Log("reset");
            for(int i=0;i<3 && WaitingRoom.transform.childCount!=0;i++)
            {
                Transform ob = WaitingRoom.transform.GetChild(0);
                ob.SetParent(transform.GetChild(i));
                ob.localPosition = Vector2.zero;
                ob.GetComponent<Image>().SetNativeSize();
                ob.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                ob.GetComponent<BoxCollider2D>().size = ob.transform.GetComponent<RectTransform>().rect.size;

            }
            if(WaitingRoom.transform.childCount == 0)
            {
                win();
            }
        }
    }
    public void win()
    {
        Debug.Log("You win!!!");
    }
}
