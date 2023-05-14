using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject panelOptions;
    // [SerializeField] GameObject player;
    private bool isPause;
    void Update()
    {
        if (panelOptions.activeSelf)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }

    private void Pause()
    {
        isPause = true;
        Time.timeScale = 0f;

        // player.active = false;

    }

    private void Unpause()
    {
        isPause = false;
        Time.timeScale = 1f;
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
