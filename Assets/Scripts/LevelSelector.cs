using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] int levels;

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level " + levels.ToString());
    }
}
