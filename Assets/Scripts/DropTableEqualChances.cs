using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTableEqualChances : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> _dropTable;

    public void AddItem(GameObject entry)
    {
        if (!_dropTable.Exists(p => p.name == entry.name))
        {
            _dropTable.Add(entry);
            //_dropTable.Sort((x, y) => x._dropchance.CompareTo(y._dropchance));
        }
        else
        {
            Debug.LogWarning($"Trying to add an already existing object in droptable {this.name}");
        }
    }

    /// <summary>
    /// Returns a random itrem
    /// </summary>
    /// <param name="tweak"></param>
    /// <returns></returns>
    public GameObject GetRandomEntry(float tweak = 0.0f)
    {
        float totalDropChance = TotalDropChance();
        float roll = Random.Range(0.0f, 100.0f) - tweak;
        roll = Mathf.Clamp(roll, 0.0f, 100.0f);

        int index = 1;
        foreach (GameObject entry in _dropTable)
        {
            roll -= index * 10.0f;
            if (roll <= 0.0f)
            {
                return entry.gameObject;
            }
        }
        return null;
    }

    public float TotalDropChance()
    {
        float result = 0.0f;
        foreach (GameObject entry in _dropTable)
        {
            result += 10.0f;
        }
        return result;
    }

}
