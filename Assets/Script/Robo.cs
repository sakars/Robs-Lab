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
    public GameObject receptionist;
    public GameObject gudRoom;

    public float lightFade = 0.5f;

    // Implement a call with the right signature for events going off

    // Start is called before the first frame update
    void Start()
    {
        gudRoom = GameObject.Find("RobExfill");
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
        //Debug.Log(needed);
        //Debug.Log(hue);
        if (needed == hue)
        {
            transform.SetParent(gudRoom.transform);
            transform.localPosition = Vector2.zero;
            receptionist.GetComponent<receptionist>().Test();
            GameObject.Find("RobSounds").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sounds/SFX_VITC_3");
            GameObject.Find("RobSounds").GetComponent<AudioSource>().Play();
        }
        else
        {
            GameObject.Find("RobSounds").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sounds/SFX_VITC_2");
            GameObject.Find("RobSounds").GetComponent<AudioSource>().Play();
            lightFade = 0.5f;
            InvokeRepeating("fade", 0.03f, 0.04f);
        }
    }
    public void fade()
    {
        lightFade += 0.05f;
        GetComponent<Image>().color = new Color(1.0f, lightFade, lightFade);
        if (lightFade > 1.0f)
        {
            CancelInvoke();
        }
    }
    
}
