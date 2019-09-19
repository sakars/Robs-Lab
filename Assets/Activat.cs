using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activat : MonoBehaviour
{
    GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetObject(GameObject displayable)
    {
        displayable.transform.SetParent(gameObject.transform);
        displayable.transform.localPosition =new Vector3(0,0,-3);
        Item = displayable;
        //Debug.Log(PlayerPrefs.GetInt("key"));
    }
}
