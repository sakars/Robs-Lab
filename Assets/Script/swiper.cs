using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class swiper : MonoBehaviour
    , IDragHandler, IEndDragHandler
{
    private Vector2 deltaValue;
    private bool dragging=false;
    private Vector2 lloc;
    private Vector2 rloc;
    private Vector2 st;
    private bool right=false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.position);
        lloc = new Vector2(Screen.width,Screen.height/2);
        rloc = new Vector2(0, Screen.height/2);
        st = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.position = st + new Vector2(deltaValue.x, 0);
        }else if (right)
        {
            st = rloc;
            transform.position = Vector2.Lerp(transform.position, rloc, 0.5f);
        }
        else
        {
            st = lloc;
            transform.position = Vector2.Lerp(transform.position, lloc, 0.5f);
        }
    }
    public void OnBeginDrag(PointerEventData data)
    {
        deltaValue = Vector2.zero;
        dragging = true;
    }

    public void OnDrag(PointerEventData data)
    {
        deltaValue += data.delta;
        dragging = true;
    }

    public void OnEndDrag(PointerEventData data)
    {
        dragging = false;
        if (deltaValue.x < -150)
        {
            right = true;
        }
        else if (deltaValue.x > 150)
        {
            right = false;
        }
        //Debug.Log(deltaValue);
        deltaValue = Vector2.zero;
    }

    public void forcePagrabs()
    {
        right = true;
        deltaValue = Vector2.zero;
    }
    public void forceTelpa()
    {
        right = false;
        deltaValue = Vector2.zero;
    }
}
