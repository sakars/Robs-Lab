using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music_toggle : MonoBehaviour
{
    // Start is called before the first frame update
    private Button yourButton;
    public static bool music_togg;
    public GameObject musto;
    void Start()
    {
        music_togg = true;
        yourButton = transform.GetComponent<Button>();
        yourButton.onClick.AddListener(ChTextureH);
    }

    void ChTextureH()
    {
        if (music_togg)
        {
            musto.GetComponent<persistors>().MusicOff();
            transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/musictoggle_off");
        }
        else
        {
            musto.GetComponent<persistors>().MusicOn();
            transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/musictoggle_on");
        }
        music_togg = !music_togg;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
