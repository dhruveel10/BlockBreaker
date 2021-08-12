using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameStatus>().NewGame(); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
