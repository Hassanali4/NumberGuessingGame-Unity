using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScreenManager
{

    private static Stack<AppScreen> _screenStack;


    //Events
    public static event Action<string> onScreenAdded;
    public static event Action<string> onScreenRemoved;



    public static void Initialize()
    {     
        SceneManager.sceneLoaded += OnLevelLoad;
    }


    private static void OnLevelLoad(Scene scene,LoadSceneMode mode)
    {
        //Clear the screen stack when a new level is loaded
        if (_screenStack == null) return;
        _screenStack.Clear();
    }


    public static void AddScreen(AppScreen screen)
    {
        Debug.Log("Added " + screen.ScreenName);
        if (_screenStack == null)
        {
            _screenStack = new Stack<AppScreen>();
        }
        _screenStack.Push(screen);
        OnScreenAdded(screen.ScreenName);
    }
    public static void PopScreen()
    {
        if (_screenStack.Count == 1)
        {
            return;
        }
        AppScreen previousScreen = _screenStack.Pop();
        OnScreenRemoved(previousScreen.ScreenName);
        OnScreenAdded(_screenStack.Peek().ScreenName);
    }

    //Since stack only allows first in last out operation we cannot remove a screen of our choice
    //So we first copy the stack into a list and then remove the item. Then we convert the list back into a stack
    public static void RemoveScreen(AppScreen screen)
    {
        if (_screenStack == null || _screenStack.Count == 1)
        {
            return;
        }
        List<AppScreen> screensCopy = _screenStack.ToList();
        if (screensCopy.Contains(screen))
        {
            screensCopy.Remove(screen);
        }
        OnScreenRemoved(screen.ScreenName);
        _screenStack = new Stack<AppScreen>(screensCopy);
        if (_screenStack.Count == 0) return;
        OnScreenAdded(_screenStack.Peek().ScreenName);
    }
    public static void OnScreenAdded(string ScreenName)
    {
        onScreenAdded?.Invoke(ScreenName);
    }
    public static void OnScreenRemoved(string ScreenName)
    {
        onScreenRemoved?.Invoke(ScreenName);
    }
}
