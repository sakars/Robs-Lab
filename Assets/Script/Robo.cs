using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Robo : MonoBehaviour
    //,IDragHandler,IEndDragHandler
{
    public int needed;
    public bool give=false;
    public int prize;
    public GameObject info;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBot()
    {
        GetComponent<Image>().sprite = info.GetComponent<RobLooks>().sprites[needed];
    }
    public void GiveLekarstvo(int hue)
    {
        Debug.Log(needed);
        Debug.Log(hue);

    }
}
