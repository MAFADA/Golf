using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    // private void OnEnable() {
    //     // check next scene available or not, (false = hide button)
    //     var currentSccene = SceneManager.GetActiveScene();
    //     int currentLevel = int.Parse(currentSccene.name.Split("Level ")[1]);
    //     int nextLevel = currentLevel+1;
    //     var nextScene = SceneManager.GetSceneByName("Level "+nextLevel);

    //     if (nextScene == null)
    //     {
    //         this.gameObject.SetActive(false);
    //     }
    // }
    
    public void NextLevel(string nextLevelName){
        SceneManager.LoadScene(nextLevelName);
    }
}
