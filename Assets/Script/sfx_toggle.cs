using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfx_toggle : MonoBehaviour
{
    // Start is called before the first frame update
    private Button yourButton;
    public static bool sfx_togg;
    void Start()
    {
        sfx_togg = true;
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(ChTexture);
    }

    void ChTexture()
    {
        if (sfx_togg)
        {
            transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/sfxtoggle_off");
        }
        else
        {
            transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/sfxtoggle_on");
        }
        sfx_togg = !sfx_togg;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
