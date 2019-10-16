using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputs : MonoBehaviour
{
    private GameLogic _gLogic;
    // Start is called before the first frame update
    void Start()
    {
        _gLogic = this.transform.parent.GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && _gLogic._state == GAMESTATE.PLAYING)
        {
            _gLogic.Pause();
        }
    }
}
