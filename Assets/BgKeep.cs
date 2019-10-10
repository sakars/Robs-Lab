using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgKeep : MonoBehaviour
{
    public static BgKeep instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            PlayerPrefs.SetInt("Tut", 0);
            Debug.Log("Tut set to " + PlayerPrefs.GetInt("Tut"));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
