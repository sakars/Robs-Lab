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
        GameObject colb=Resources.Load<GameObject>("combs/Colb");
        GameObject[] order = GameObject.Find("CombineButton").transform.GetComponent<combiner>().order;
        for (int i = 0; i < Ldata.colbHues.Length; i++)
        {
            GameObject newC = GameObject.Instantiate(colb, order[Ldata.colbLoc[i]].transform);
            UIInp sc = newC.GetComponent<UIInp>();
            sc.SetHue(Ldata.colbHues[i] * 0.1f);
            sc.SetFill(Ldata.colbFills[i]);
            newC.transform.localPosition = new Vector3();
            newC.transform.localScale = new Vector3(1, 1, 1);
        }
        GameObject bot = Resources.Load<GameObject>("combs/Robs");
        for(int i = 0; i < Ldata.botHues.Length; i++)
        {
            //GameObject newB = GameObject.Instantiate(bot,);
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

