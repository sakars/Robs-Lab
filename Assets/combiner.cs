using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combiner : MonoBehaviour
{
    // Start is called before the first frame update
    public Button yourButton;
    public GameObject keeper;
    public Transform com_1;
    public Transform com_2;
    private int it_1;
    private int it_2;
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
        it_1 = com_1.GetComponent<Activat>().Item;
        it_2 = com_2.GetComponent<Activat>().Item;
        string key = pairingF(it_1, it_2);
        GameObject ob = recepies.GiveResult(key);
        if (ob != null)
        {
            com_1.GetComponent<Activat>().clearThat();
            com_2.GetComponent<Activat>().clearThat();
            com_1.GetComponent<Activat>().Item = -1;
            com_2.GetComponent<Activat>().Item = -1;

            ob = GameObject.Instantiate(ob, new Vector3(0, -80), new Quaternion(), GameObject.Find("Movables").transform);
            ob.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -80);
            Debug.Log(ob.GetComponent<UIInp>().Name);
        }
    }
    public string pairingF(int x,int y)
    {
        return (x+y).ToString()+"_"+(x*y).ToString();
    }
}
