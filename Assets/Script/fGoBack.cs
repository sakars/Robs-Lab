using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fGoBack : MonoBehaviour
{
    private Button yourButton;
    public GameObject dis;
    public GameObject ena;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(GoBack);
    }
    void GoBack()
    {
        ena.SetActive(true);
        dis.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
