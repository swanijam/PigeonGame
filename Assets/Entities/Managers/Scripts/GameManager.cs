using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    [HideInInspector]
    public InputHandler INPUTHANDLER;

    private static GameManager _gameManager;

    private GameManager()
    {
        INPUTHANDLER = new MouseAndKeyboardInputHandler();
    }

    public static GameManager GetInstance()
    {
        if (_gameManager == null)
            _gameManager = new GameManager();

        return _gameManager;
    }
}
