using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnEnemyDeathRollDrop : MonoBehaviour
{
    public float _dropRateTweak = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnEnemyDeath.AddListener(OnEnemyDeath);
    }

    private void OnEnemyDeath(DeathEventArguments arg)
    {
        GameObject dropPrefab = Core.dropTables.GetFromTable("Default", _dropRateTweak);
        if(dropPrefab != null)
        {
            GameObject drop = Instantiate(dropPrefab);
            drop.transform.position = arg.Location;
            drop.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
