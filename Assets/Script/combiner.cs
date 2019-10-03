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
    private int it_1;
    private int it_2;
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        //yourButton.onClick.AddListener(combine);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
