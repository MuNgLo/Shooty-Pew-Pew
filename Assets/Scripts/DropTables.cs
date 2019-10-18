using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTables : MonoBehaviour
{
    private Dictionary<string, DropTableEqualChances> Tables;
    void Awake()
    {
        Core.dropTables = this;
        Tables = new Dictionary<string, DropTableEqualChances>();
    }

    void Start()
    {
        foreach(Transform child in this.transform)
        {
            if (child.GetComponent<DropTableEqualChances>())
            {
                if (!Tables.ContainsKey(child.name))
                {
                    Tables[child.name] = child.GetComponent<DropTableEqualChances>();
                }
            }
        }
    }

    public GameObject GetFromTable(string name, float weight= 0.0f)
    {
        if (Tables.ContainsKey(name))
        {
            return Tables[name].GetRandomEntry(weight);
        }
        return null;
    }
}
