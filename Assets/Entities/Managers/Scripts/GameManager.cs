using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    [HideInInspector]
    public InputHandler INPUTHANDLER;
    private CameraShake _shakyCamera;

    private static GameManager _gameManager;

    private GameManager()
    {
        INPUTHANDLER = new MouseAndKeyboardInputHandler();
        GameObject effectCamera = GameObject.FindGameObjectWithTag(CameraShake.ATTATCHED_TAG);
        if (effectCamera != null)
            _shakyCamera = effectCamera.GetComponent<CameraShake>();
    }

    public static GameManager GetInstance()
    {
        if (_gameManager == null)
            _gameManager = new GameManager();

        return _gameManager;
    }

    public void AddCameraTrauma(float value)
    {
        if (_shakyCamera != null)
            _shakyCamera.AddTrauma(value);
    }
}
