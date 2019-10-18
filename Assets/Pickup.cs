using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PICKUPS _type = PICKUPS.UNSET;

    internal void Apply()
    {
        switch (_type)
        {
            case PICKUPS.LASER:
                Core.localPlayer.SelectWeapon("Laser");
                break;
            case PICKUPS.PLASMA:
                Core.localPlayer.SelectWeapon("Plasma");
                break;
            case PICKUPS.UNSET:
            default:
                Debug.LogWarning("Pickup with UNSET type!");
                break;
        }
        GameObject.Destroy(this.gameObject);
    }
}
