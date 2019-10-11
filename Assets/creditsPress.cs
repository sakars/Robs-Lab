using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creditsPress : MonoBehaviour
{
    private Button yourButton;
    public GameObject disableable;
    public GameObject dis2;
    // Start is called 
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(Toggle);
    }
    void Toggle()
    {
        disableable.SetActive(!disableable.activeSelf);
        dis2.SetActive(!dis2.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
