using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundEffectPlayer : MonoBehaviour
{
    public AudioClip _sound;

    public bool _onHit = false;
    public bool _onDeath = false;
    public bool _onPlayerDeath = false;
    public bool _onFire = false;

    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        if (_onDeath) { GameEvents.OnEnemyDeath.AddListener(PlaySound);}
        if (_onPlayerDeath) { GameEvents.OnPlayerDeath.AddListener(PlaySound); }
        if (_onHit) { GameEvents.OnHit.AddListener(PlaySound); }
        if (_onFire) { GameEvents.OnFire.AddListener(PlaySound); }
    }

    private void PlaySound(DeathEventArguments arg0)
    {
        _audio.PlayOneShot(_sound);
    }

    private void PlaySound()
    {
        _audio.PlayOneShot(_sound);
    }
}
