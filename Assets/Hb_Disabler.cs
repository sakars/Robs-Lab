using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hb_Disabler : MonoBehaviour
{
    bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (transform.childCount == 0)
            {
                on = false;
                foreach(var script in Activat.instances)
                {
                    script.SetHb(on);
                }
            }
        }
        else
        {
            if (transform.childCount == 1)
            {
                on = true;
                foreach (var script in Activat.instances)
                {
                    script.SetHb(on);
                }
            }
        }
    }
}
