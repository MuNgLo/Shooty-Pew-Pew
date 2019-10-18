using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

public enum GAMESTATE { MAINMENU, PLAYING, PAUSED, POSTRUN, DEATHSCREEN }
public enum SPAWNSIDE { TOP, RIGHT }
public enum ROUTENAMES { UNSET, TOPPASS, MIDPASS, BOTTOMPASS, LEFTPASS, RIGHTPASS }
public enum ENEMYTYPE { UNSET, BASIC, SHOOTER, SPAMMER }
public enum PICKUPS { UNSET, LASER, PLASMA }

public class HurtsToTouch : MonoBehaviour
{
    public int _damageOnTouch = 0;
}
public abstract class CanTakeDamage : MonoBehaviour
{
    abstract internal void TakeDamage(Weapons.Payload payload);
}


public static class Core
{
    internal static DropTables dropTables;
    internal static GameLogic gLogic = null;
    internal static RouteManager Routes = null;
    internal static MenuSystem menus = null;
    internal static RunManager run = null;
    internal static Enemies.EnemyManager enemies = null;
    internal static Transform player = null;
    internal static LocalPLayer localPlayer = null;
}
public static class GameEvents
{
    static public UnityEvent OnPlayerTakingDamage = new UnityEvent();
    static public UnityEvent OnPlayerDeath = new UnityEvent();
    static public EnemyDeathEvent OnEnemyDeath = new EnemyDeathEvent();
    static public UnityEvent OnHit = new UnityEvent();
    static public UnityEvent OnFire = new UnityEvent();
    static public UnityEvent OnStartRun = new UnityEvent();
    static public UnityEvent OnEndRun = new UnityEvent();
    static public RunTicEvent OnRunTic = new RunTicEvent();

    static public void RaiseOnEnemyDeath(DeathEventArguments args)
    {
        OnEnemyDeath?.Invoke(args);
    }
    static public void RaiseOnHit()
    {
        OnHit?.Invoke();
    }
    static public void RaiseOnFire()
    {
        OnFire?.Invoke();
    }



    static public void RaiseOnRunTic(int value)
    {
        OnRunTic?.Invoke(value);
    }
    static public void RaiseOnStartRun()
    {
        OnStartRun?.Invoke();
    }
    static public void RaiseOnEndRun()
    {
        OnEndRun?.Invoke();
    }

    internal static void RaiseOnPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }
}
[System.Serializable]
public struct EnemyCourse
{
    public ROUTENAMES Name;
    public Transform Spawnpoint;
    public Transform AltSpawnpoint;
    public List<Transform> Plots;
}
[System.Serializable]
public struct DeathEventArguments
{
    public Vector3 Location;
}
[System.Serializable]
public class RunTicEvent : UnityEvent<int>
{

}
[System.Serializable]
public class EnemyDeathEvent : UnityEvent<DeathEventArguments>
{

}

