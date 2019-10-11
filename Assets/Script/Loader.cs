using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
    public int level;
    public GameObject Sign;
    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("Clevel");
        Load();
    }

    // Update is called once per framey
    void Update()
    {
        
    }
    public void Load()
    {
        //TextAsset txt = Resources.Load<TextAsset>("Level jsons/" + level.ToString());
        Sign.GetComponent<Text>().text = "Level " + level;
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
        Debug.Log(bot);
        for(int i = Ldata.botHues.Length - 1; i >= 0; i--)
        {
            GameObject newB = GameObject.Instantiate(bot,GameObject.Find("Remaining_bots").transform);
            newB.transform.SetAsFirstSibling();
            newB.GetComponent<Robo>().info = gameObject;
            newB.GetComponent<Robo>().needed = Ldata.botHues[i];
            if (Ldata.botPrizes[i]!=11)
            {
                newB.GetComponent<Robo>().give = true;
                newB.GetComponent<Robo>().prize = Ldata.botPrizes[i];
            }
            newB.GetComponent<Robo>().Receptionist = GameObject.Find("roblocs");
            newB.GetComponent<Robo>().SetBot();
            newB.SetActive(true);
        }
        GameObject.Find("roblocs").GetComponent<receptionist>().Test();
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

