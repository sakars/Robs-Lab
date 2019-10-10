using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelFetch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 2; i < 6; i++)
        {
            if(PlayerPrefs.HasKey("Lvl" + i.ToString()) && PlayerPrefs.GetInt("Lvl" + i.ToString()) == 1){
                transform.GetChild(i + 2).GetComponent<Button>().interactable = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
