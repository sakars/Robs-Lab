using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tog : MonoBehaviour
{
    private Button yourButton;
    public GameObject disableable;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(Toggle);
    }
    void Toggle()
    {
        disableable.SetActive(!disableable.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
