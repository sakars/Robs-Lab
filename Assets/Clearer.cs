using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIInp.instances = new List<UIInp>();
        Activat.instances = new List<Activat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
