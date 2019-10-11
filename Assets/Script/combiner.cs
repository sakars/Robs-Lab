using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combiner : MonoBehaviour
{
    // Start is called before the first frame update
    private Button yourButton;
    public Transform com_1;
    public Transform com_2;
    private Color it_1;
    private Color it_2;
    public Transform outage;
    public GameObject[] order;
    public static GameObject[] ord;
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(combine);
        ord = order;
        //GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void combine()
    {
        if (com_1.childCount != 0 && com_2.childCount != 0)
        {
            bool don = false;
            GameObject fill;
            it_1 = com_1.GetChild(0).GetComponent<Image>().color;
            it_2 = com_2.GetChild(0).GetComponent<Image>().color;
            float hue1;
            float t;
            Color.RGBToHSV(it_1, out hue1, out t, out t);
            float hue2;
            Color.RGBToHSV(it_2, out hue2, out t, out t);
            //float distance = Mathf.Abs(hue1 - hue2);
            float mid;
            mid = (hue1 + hue2) / 2;
            /*if (distance > 0.5f)
            {
                distance = 1 - distance;
                mid = (Mathf.Max(hue1, hue2) + distance / 2);
            }
            else
            {
                mid = (Mathf.Max(hue1, hue2) - distance / 2);
            }*/
            mid *= 10f;
            mid = Mathf.Round(mid + 0.1f);
            mid /= 10f;
            mid %= 1;
            Debug.Log(mid);
            UIInp sc1 = com_1.GetChild(0).GetComponent<UIInp>();
            UIInp sc2 = com_2.GetChild(0).GetComponent<UIInp>();
            foreach (var slot in order)
            {
                if (slot.transform.childCount == 0)
                {
                    sc1.fill -= 25;
                    sc2.fill -= 25;
                    sc1.SetFill(sc1.fill);
                    sc2.SetFill(sc2.fill);
                    GameObject ob = Resources.Load<GameObject>("combs/Colb");
                    ob = GameObject.Instantiate(ob, slot.transform);
                    ob.GetComponent<UIInp>().fill = 50;
                    ob.GetComponent<UIInp>().SetFill();
                    ob.GetComponent<Image>().color = Color.HSVToRGB(mid, 1, 1);
                    ob.transform.position = outage.transform.position;
                    ob.transform.localScale = new Vector3(1, 1, 1);
                    don = true;
                    GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sounds/SFX_VITC_4");
                    GetComponent<AudioSource>().volume = 0.35f;
                    GetComponent<AudioSource>().Play();
                    break;

                }
            }
            if (don == false)
            {
                GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sounds/SFX_VITC_5");
                GetComponent<AudioSource>().volume = 0.4f;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sounds/SFX_VITC_5");
            GetComponent<AudioSource>().volume = 0.4f;
            GetComponent<AudioSource>().Play();
        }
    }
}
