using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour {
    public float _TTL = 10.0f;
    private float timeLeft = 0.0f;

	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0.0f)
        {
            //if (GetComponent<PooledObject>())
            //{
            //    Core.pool.ReturnToPool(GetComponent<PooledObject>());
            //}
            //else
            //{
                GameObject.Destroy(this.gameObject);
            //}
        }
	}
    private void OnEnable()
    {
        timeLeft = _TTL;
    }
}
