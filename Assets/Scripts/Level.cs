using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 3f;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverScreen());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadGameOverScreen()
    {
        var music = FindObjectsOfType<MusicPlayer>();
        Debug.Log(music);
        for (int i = 0; i < music.Length; i++)
        {
            Destroy(music[i].gameObject);
        }
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }
}
