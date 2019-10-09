using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInp : MonoBehaviour
    , IDragHandler, IEndDragHandler
{
    public static List<UIInp> instances=new List<UIInp>();
    public int fill=100;
    [HideInInspector]
    public GameObject prParent;
    private GameObject mov;
    private bool drag = false;
    private GameObject colber;
    private GameObject colber2;
    private void Start()
    {
        colber = GameObject.Find("ColbSounds");
        colber2 = GameObject.Find("ColbPlace");
        prParent = transform.parent.gameObject;
        mov = GameObject.Find("Movs");
        instances.Add(this);
    }
    private void Update()
    {
        if (!drag)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, new Vector2(), 0.5f);
            
        }
    }
    public void SetFill(int value)
    {
        if (value == 0)
        {
            Destroy(gameObject);
            instances.Remove(this);
        }
        else
        {
            //Debug.Log("Images/colbs/kolb_2_" + value.ToString());
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/colbs/kolb_2_" + value.ToString());
        }
        fill = value;
    }
    public void SetFill()
    {
        if (fill == 0)
        {
            Destroy(gameObject);
            instances.Remove(this);
        }
        else
        {
            //Debug.Log("Images/colbs/kolb_2_" + fill.ToString());
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/colbs/kolb_2_" + fill.ToString());
        }
    }
    public float GetHue()
    {
        float hue;
        Color.RGBToHSV(GetComponent<Image>().color, out hue,out float i,out float i2);
        return hue;
    }
    public void SetHue(float hue)
    {
        GetComponent<Image>().color = Color.HSVToRGB(hue, 1, 1);
    }
    public void OnDrag(PointerEventData data)
    {
        drag = true;
        transform.position = data.position;
        transform.SetParent(mov.transform);
    }
    public void OnEndDrag(PointerEventData data)
    {
        drag = false;
        ContactFilter2D filter = new ContactFilter2D();
        Collider2D[] res = new Collider2D[2];
        int cols = GetComponent<BoxCollider2D>().OverlapCollider(filter,res);
        if (res[0])
        {
            if (res[0].transform.GetComponent<Activat>())
            {
                //Debug.Log(res[0].gameObject);
                if (res[0].transform.childCount != 0)
                {
                    //Debug.Log(prParent.name);
                    //Debug.Log(res[0].transform.GetChild(0).GetComponent<UIInp>().prParent);
                    res[0].transform.GetChild(0).GetComponent<UIInp>().prParent = prParent;
                    res[0].transform.GetChild(0).SetParent(prParent.transform);
                    colber.GetComponent<AudioSource>().Play();
                }
                else
                {
                    colber2.GetComponent<AudioSource>().Play();
                }
                prParent = res[0].gameObject;
            }
            else if (res[0].transform.GetComponent<Robo>())
            {
                fill -= 25;
                SetFill();
                res[0].transform.GetComponent<Robo>().GiveLekarstvo((int)(GetHue()*10));
            }
        }
        transform.SetParent(prParent.transform);
    }
}
