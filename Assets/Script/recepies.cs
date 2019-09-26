using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recepies : MonoBehaviour
{
    public static recepies instance;
    public Dictionary<string, GameObject> mats;
    public Dictionary<string, string> recs;
    TextAsset textA;
    CReader combs;
    void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        mats = new Dictionary<string, GameObject>();
        recs = new Dictionary<string, string>();
        TextAsset textA = Resources.Load("Recepies") as TextAsset;
        GameObject[] res = Resources.LoadAll<GameObject>("combs");
        for (int i = 0; i < res.Length; i++)
        {
            mats.Add(res[i].GetComponent<UIInp>().Name.ToString(), res[i]);
        }
        string text = textA.text;
        combs = JsonUtility.FromJson<CReader>(text);
        /*Debug.Log(combs.combs[0].key);
        Debug.Log(combs.combs[0].value);*/
        for (int i = 0; i < combs.combs.Count; i++)
        {
            recs.Add(combs.combs[i].key, combs.combs[i].value);
        }
    }
    public static GameObject GiveResult(string key)
    {
        string k = key;
        Debug.Log(k);

        if (instance.recs.ContainsKey(k))
        {
            if (instance.mats.ContainsKey(instance.recs[k]))
            {
                return instance.mats[instance.recs[k]];
            }
        }
        return null;
    }
    [System.Serializable]
    private class CReader
    {
        public List<Combination> combs;
    }
    [System.Serializable]
    private class Combination
    {
        // Start is called before the first frame update
        public string key;
        public string value;
    }
}
