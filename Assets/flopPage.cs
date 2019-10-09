using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flopPage : MonoBehaviour
{
    // Start is called before the first frame update
    private Button yourButton;
    public GameObject theman;
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(theman.GetComponent<tutorial>().Advance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
