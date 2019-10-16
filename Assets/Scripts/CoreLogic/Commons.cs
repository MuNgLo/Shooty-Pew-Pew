using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GAMESTATE { MAINMENU, PLAYING, PAUSED, POSTRUN, DEATHSCREEN }
public enum DAMAGETYPE { ENERGY, EXPLOSIVE }

public class HurtsToTouch : MonoBehaviour
{
    public int _damageOnTouch = 0;
}

public static class Core
{
    internal static GameLogic gLogic;
    internal static RouteManager Routes;
    internal static MenuSystem menus;
    internal static RunManager run;
    internal static Enemies.EnemyManager enemies;
    internal static Transform player;
}
public static class GameEvents
{
    static public UnityEvent OnPlayerTakingDamage = new UnityEvent();
    static public UnityEvent OnPlayerDeath = new UnityEvent();
    static public UnityEvent OnStartRun = new UnityEvent();
    static public UnityEvent OnEndRun = new UnityEvent();
    static public RunTicEvent OnRunTic = new RunTicEvent();

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
    public string Name;
    public Transform Spawnpoint;
    public List<Transform> Plots;
}
[System.Serializable]
public class RunTicEvent : UnityEvent<int>
{

}

