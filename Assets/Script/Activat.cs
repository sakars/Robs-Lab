using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activat : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<Activat> instances=new List<Activat>();
    void Start()
    {
        instances.Add(transform.GetComponent<Activat>());
    }
    public void SetHb(bool active)
    {
        transform.GetComponent<BoxCollider2D>().enabled = active;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
