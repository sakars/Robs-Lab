using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activat : MonoBehaviour
{
    public int Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clearThat()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void SetObject(GameObject displayable,int Str)
    {
        displayable.transform.SetParent(gameObject.transform);
        displayable.transform.localPosition =new Vector3(0,0,-3);
        Item = Str;
        //Debug.Log(PlayerPrefs.GetInt("key"));
    }
}
