using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonSound : MonoBehaviour
{
    private Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(Go);
    }
    void Go()
    {
        transform.GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
