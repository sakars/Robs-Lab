using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
public class Loader : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load()
    {
        //TextAsset txt = Resources.Load<TextAsset>("Level jsons/" + level.ToString());
        Debug.Log(level.ToString());
        TextAsset mytxtData = (TextAsset)Resources.Load("LevelJsons/Lvl" + level.ToString());
        string txt = mytxtData.text;
        Debug.Log(txt);
        Layer1 Ldata = JsonUtility.FromJson<Layer1>(txt);
        Debug.Log(Ldata.colbHues.Length);
        foreach(var thing in Ldata.botPrizes)
        {
            Debug.Log(thing);
        }
    }
    private class Layer1
    {
        public int[] colbHues;
        public int[] colbFills;
        public int[] colbLoc;
        public int[] botHues;
        public int[] botPrizes;
    }
}

