using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelState
{
    Level1,
    Level2,
    Level3
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Components")]
    public Player player;
    public GameObject endGameUI;

    [Header("Level Info")]
    public LevelState levelState;
    public bool levelFinished;
    public int woodNumber;

    private void Awake()
    {
        instance = this;
    }

    public void LevelEnd()
    {
        endGameUI.SetActive(true);
    }

    public void Level1Button()
    {
        SceneManager.LoadScene("Level-1");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("Level-2");
    }

    public void Level3Button()
    {
        SceneManager.LoadScene("Level-3");
    }
}
