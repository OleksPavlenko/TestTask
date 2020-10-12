using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _gameIsPaused;

    public void PauseGame()
    {
        _gameIsPaused = !_gameIsPaused;

        if (_gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
