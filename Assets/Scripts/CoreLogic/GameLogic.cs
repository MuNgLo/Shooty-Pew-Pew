using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GAMESTATE _state = GAMESTATE.MAINMENU;
    public GameObject _playerAvater;
    public Vector3 _startPosition;
    public int _lives = 0;
    private void Awake()
    {
        Core.gLogic = this;
    }
    private void Start()
    {
        _startPosition = _playerAvater.transform.position;
        GameEvents.OnPlayerDeath.AddListener(OnPlayerDeath);
    }

    internal bool IsPlayerAlive()
    {
        return _playerAvater.activeSelf;
    }

    private void OnPlayerDeath()
    {
        _playerAvater.SetActive(false);
        _lives -= 1;
        if(_lives <= 0)
        {
            GameOver();
            return;
        }
        StartCoroutine("SpawnIn");
    }

    IEnumerator SpawnIn()
    {
        Core.localPlayer._weapon._canShot = false;
        Core.localPlayer._hitbox.enabled = false;
        yield return new WaitForSeconds(1.5f);
        _playerAvater.SetActive(true);
        float timer = 0.0f;
        while (timer < 2.0f)
        {
            Core.localPlayer._sprite.enabled = !Core.localPlayer._sprite.enabled;

            timer += 0.01666f;
            yield return new WaitForSeconds(0.01666f);
        }
        Core.localPlayer._hitbox.enabled = true;
        Core.localPlayer._sprite.enabled = true;
        Core.localPlayer._weapon._canShot = true;
    }

    internal void EndOfLevelReached()
    {
        if(Core.enemies.EnemyCount > 0) { return; }
        _playerAvater.SetActive(false);
        _state = GAMESTATE.POSTRUN;
        Core.menus.GotToMenu("Completed");
        GameEvents.RaiseOnEndRun();
        StartCoroutine("CompletionscreenTimer");
    }

    IEnumerator DeathscreenTimer()
    {
        yield return new WaitForSeconds(5.0f);
        _state = GAMESTATE.MAINMENU;
        Core.menus.GotToMenu("MainMenu");
    }
    IEnumerator CompletionscreenTimer()
    {
        yield return new WaitForSeconds(5.0f);
        _state = GAMESTATE.MAINMENU;
        Core.menus.GotToMenu("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        _state = GAMESTATE.PLAYING;
        Core.menus.GotToMenu("GameUI");
        _lives = 3;
        GameEvents.RaiseOnStartRun();
        _playerAvater.transform.position = _startPosition;
        StartCoroutine("SpawnIn");
    }

    public void Pause()
    {
        if (_state == GAMESTATE.PLAYING)
        {
            _state = GAMESTATE.PAUSED;
            Core.menus.GotToMenu("PauseMenu");
            Time.timeScale = 0.0f;
        }
    }
    public void UnPause()
    {
        _state = GAMESTATE.PLAYING;
        Core.menus.GotToMenu("GameUI");
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        _state = GAMESTATE.DEATHSCREEN;
        _playerAvater.SetActive(false);
        Core.menus.GotToMenu("DeathScreen");
        GameEvents.RaiseOnEndRun();
        StartCoroutine("DeathscreenTimer");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
