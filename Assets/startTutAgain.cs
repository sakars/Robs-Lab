using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startTutAgain : MonoBehaviour
{
    private Button yourButton;
    public GameObject tuterer;
    // Start is called before the first frame updateate
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(Toggle);
    }
    void Toggle()
    {
        tuterer.GetComponent<tutorial>().redo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
