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
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(combine);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void combine()
    {
        it_1 = com_1.GetChild(0).GetChild(0).GetComponent<Image>().color;
        it_2 = com_2.GetChild(0).GetChild(0).GetComponent<Image>().color;
        float hue1;
        float t;
        Color.RGBToHSV(it_1, out hue1,out t,out t);
        float hue2;
        Color.RGBToHSV(it_2, out hue2, out t, out t);
        Debug.Log(hue1);
        Debug.Log(hue2);
        transform.GetComponent<Image>().color = Color.HSVToRGB((hue1 + hue2) / 2, 1, 1);
        
    }
}
