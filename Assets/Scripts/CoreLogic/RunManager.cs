using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    [Header("Leveldefinitions")]
    public int _levelLength = 100;

    [Header("CurrentRunNumbers")]
    public float _travelled = 0;
    public float _travelSpeed = 1.0f;
    public int _lastTic = 0;

    private void Start()
    {
        GameEvents.OnEndRun.AddListener(ResetRun);
    }

    private void Update()
    {
        if(Core.gLogic._state == GAMESTATE.PLAYING)
        {
            _travelled += _travelSpeed * Time.deltaTime;
            int frameTic = Mathf.FloorToInt(_travelled);
            if(frameTic != _lastTic)
            {
                GameEvents.RaiseOnRunTic(frameTic);
                _lastTic = frameTic;
            }
            if(frameTic >= _levelLength)
            {
                Core.gLogic.EndOfLevelReached();
            }
        }
        
    }

    /// <summary>
    /// This runs on run end
    /// </summary>
    private void ResetRun()
    {
        _travelled = 0;
        _travelSpeed = 1.0f;
        _lastTic = 0;
    }


}
