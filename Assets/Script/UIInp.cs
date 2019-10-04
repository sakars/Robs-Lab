﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInp : MonoBehaviour
    , IDragHandler, IEndDragHandler
{
    public int fill=100;
    [HideInInspector]
    public GameObject prParent;
    private GameObject mov;
    private Vector3 prLocation;
    private bool drag = false;
    private void Start()
    {
        prLocation = transform.localPosition;
        prParent = transform.parent.gameObject;
        mov = GameObject.Find("Movs");
    }
    private void Update()
    {
        if (!drag)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, prLocation, 0.5f);
            
        }
    }
    public void SetFill(int value)
    {
        if (value == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Images/colbs/kolb_2_" + value.ToString());
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/colbs/kolb_2_" + value.ToString());
        }
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
            if (res[0].GetComponent<UIInp>())
            {
                res[0] = res[1];
            }
            Debug.Log(res[0].gameObject);
            if (res[0].transform.childCount != 0)
            {
                Debug.Log(prParent.name);
                Debug.Log(res[0].transform.GetChild(0).GetComponent<UIInp>().prParent);
                res[0].transform.GetChild(0).GetComponent<UIInp>().prParent = prParent;
                res[0].transform.GetChild(0).SetParent(prParent.transform);
            }
            prParent = res[0].gameObject;
            prLocation = new Vector2();
        }
        transform.SetParent(prParent.transform);
    }
}
