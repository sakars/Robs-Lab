using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInp : MonoBehaviour
    , IDragHandler, IEndDragHandler
{
    public int hue;
    private GameObject prParent;
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
        filter.minDepth = -2;
        Collider2D[] res = new Collider2D[1];
        int cols = GetComponent<BoxCollider2D>().OverlapCollider(filter, res);
        if (res[0])
        {
            Debug.Log(res[0].gameObject);
            if (res[0].transform.childCount == 0)
            {
                prParent = res[0].gameObject;
                prLocation = new Vector2();
            }
            //count++;
            //PlayerPrefs.SetInt("key", count);
        }
        transform.SetParent(prParent.transform);
    }
    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        drag = true;
        if (transform.parent.GetComponent<Activat>())
        { 
            transform.parent.GetComponent<Activat>().Item = -1;
        }
        transform.SetParent(OGParent);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HI");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        drag = false;
        ContactFilter2D filter = new ContactFilter2D();
        filter.minDepth = -2;
        Collider2D[] res = new Collider2D[1];
        int cols = GetComponent<BoxCollider2D>().OverlapCollider(filter, res);
        if (res[0])
        {
            Debug.Log(res[0].gameObject);
            GameObject field = res[0].gameObject;
            //count++;
            //PlayerPrefs.SetInt("key", count);
            field.GetComponent<Activat>().SetObject(gameObject,hue);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("BYE");
    }
    // Start is called before the first frame update
    void Start()
    {
        OGParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (drag)
        {
            transform.position = Input.mousePosition;
        }
    }*/
}
