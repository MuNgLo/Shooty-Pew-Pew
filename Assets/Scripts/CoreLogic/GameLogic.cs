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
        yield return new WaitForSeconds(2.0f);
        _playerAvater.SetActive(true);
    }

    internal void EndOfLevelReached()
    {
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
