using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressionSLider : MonoBehaviour
{
    private Slider _bar;
    // Start is called before the first frame update
    void Start()
    {
        _bar = GetComponent<Slider>();
        GameEvents.OnRunTic.AddListener(NewTic);
    }

    private void NewTic(int tic)
    {
        _bar.value = tic;
    }
}
