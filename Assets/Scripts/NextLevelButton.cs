using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    private void OnEnable()
    {
        // check next scene available or not, (false = hide button)
        var currentSccene = SceneManager.GetActiveScene();
        int currentLevel = int.Parse(currentSccene.name.Split("Level ")[1]);
        int nextLevel = currentLevel + 1;
        var nextSceneBuildIndex = SceneUtility.GetBuildIndexByScenePath("Level " + nextLevel);

        if (nextSceneBuildIndex == -1)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void NextLevel()
    {
        var currentSccene = SceneManager.GetActiveScene();
        int currentLevel = int.Parse(currentSccene.name.Split("Level ")[1]);
        int nextLevel = currentLevel + 1;
        SceneManager.LoadScene("Level " +nextLevel);
        
    }
}