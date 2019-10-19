using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParticleEffectPlayer : MonoBehaviour
{
    public GameObject _particleEffect;

    [Header("On Hits")]
    public bool _onHit = false;
    public bool _onLaserHit = false;
    public bool _onPlasmaHit = false;
    [Header("Misc.")]
    public bool _onDeath = false;
    public bool _onPlayerDeath = false;
    public bool _onFire = false;

    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        if (_onHit) { GameEvents.OnHit.AddListener(PlayParticleEffect); }
    }

    

    private void PlayParticleEffect(WeaponHitEventArguments args)
    {
        Debug.Log("PlayParticleEffect");
        if (_onLaserHit && args.WeaponType == Weapons.WEAPONTYPE.LASER)
        {
            Instantiate(_particleEffect, args.Location, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }
        if (_onPlasmaHit && args.WeaponType == Weapons.WEAPONTYPE.PLASMA)
        {
            Instantiate(_particleEffect, args.Location, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }
    }
}
