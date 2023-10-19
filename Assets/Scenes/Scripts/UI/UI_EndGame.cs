using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager gameManager = GameManager.instance;

        if (other.tag == "Player")
        {
            if (gameManager.levelState == LevelState.Level1 && gameManager.woodNumber == 3)
            {
                gameManager.levelFinished = true;
                gameManager.LevelEnd();
            }
            else if (gameManager.levelState == LevelState.Level2)
            {
                gameManager.levelFinished = true;
                gameManager.LevelEnd();
            }
            else if (gameManager.levelState == LevelState.Level3 && gameManager.woodNumber == 2)
            {
                gameManager.levelFinished = true;
                gameManager.LevelEnd();
            }
        }
    }
}
