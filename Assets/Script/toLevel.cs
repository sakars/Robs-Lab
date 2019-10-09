using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class toLevel : MonoBehaviour
{
    public string TransportTo;
    public int level;
    private Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(Go);
    }
    void Go()
    {
        PlayerPrefs.SetInt("Clevel", level);
        SceneManager.LoadScene(TransportTo);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
