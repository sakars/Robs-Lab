using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInp : MonoBehaviour
    , IPointerEnterHandler , IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public int Name;
    private bool drag = false;
    private Transform OGParent;
    public void OnPointerDown(PointerEventData eventData)
    {
        drag = true;
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
            field.GetComponent<Activat>().SetObject(gameObject,Name);
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
    }
}
