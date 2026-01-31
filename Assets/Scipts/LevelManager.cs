using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    public void LoadByIndex (int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   public void LoadNext()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current +1);
    }
}
