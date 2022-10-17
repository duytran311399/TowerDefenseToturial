using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;
    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;
        if(PlayerStart.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        isGameOver = true;
        Debug.Log("GameOver");
    }
}
