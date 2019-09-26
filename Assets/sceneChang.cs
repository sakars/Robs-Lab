using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sceneChang : MonoBehaviour
{
    public string TransportTo;
    private Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(Go);
    }
    void Go()
    {
        SceneManager.LoadScene(TransportTo);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
