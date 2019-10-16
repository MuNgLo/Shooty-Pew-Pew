using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour {
    public GameObject _startMenu;

    private Dictionary<string, GameObject> _menus = new Dictionary<string, GameObject>();
    public GameObject _lastMenu = null, _currentMenu = null;

    void Awake () {
        Core.menus = this;
        DontDestroyOnLoad(this);
		foreach(Transform child in transform)
        {
            if (!_menus.ContainsKey(child.name))
            {
                _menus[child.name] = child.gameObject;
            }
        }
        HideAllMenus();
        _startMenu.SetActive(true);
        _currentMenu = _startMenu;
	}


    public void GotToMenu(string menuName)
    {
        if (!_menus.ContainsKey(menuName))
        {
            return;
        }
        HideAllMenus();
        _lastMenu = _currentMenu;
        _currentMenu = _menus[menuName];
        _menus[menuName].SetActive(true);
    }

    public void GoToPreviousMenu()
    {
        HideAllMenus();
        _currentMenu = _lastMenu;
        _currentMenu.SetActive(true);
    }

    public void HideMenu()
    {
        HideAllMenus();
    }

    public void ShowMenu()
    {
        HideAllMenus();
        _currentMenu.SetActive(true);
    }

    private void HideAllMenus()
    {
        foreach(string key in _menus.Keys)
        {
            _menus[key].SetActive(false);
        }
    }


}
