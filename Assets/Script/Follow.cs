using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject MamaDuck;
    private Vector3 Delta;
    // Start is called before the first frame update
    void Start()
    {
        Delta = MamaDuck.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = MamaDuck.transform.position - Delta;
    }
}
