using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    //private int count=0;


    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        transform.parent = null;
    }

    void OnMouseUp()
    {
        dragging = false;
        ContactFilter2D filter = new ContactFilter2D();
        filter.minDepth = -2;
        Collider2D[] res=new Collider2D[1];
        int cols = GetComponent<BoxCollider2D>().OverlapCollider(filter,res);
        if (res[0]) {
            Debug.Log(res[0].gameObject);
            GameObject field = res[0].gameObject;
            //count++;
            //PlayerPrefs.SetInt("key", count);
            field.GetComponent<Activat>().SetObject(gameObject);
        }
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x,rayPoint.y);
        }
    }
    
}