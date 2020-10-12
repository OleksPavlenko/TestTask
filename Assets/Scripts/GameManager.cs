using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public void PauseGame()
    {
        Time.timeScale = Time.timeScale == 1 ? 0f : 1;
    }
}
