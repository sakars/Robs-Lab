using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBetween : MonoBehaviour
{
    private Button yourButton;
    public GameObject dis;
    public GameObject ena;
    private GameObject tmp;
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
        tmp = ena;
        ena = dis;
        dis = tmp;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
