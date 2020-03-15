using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
            Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextScene", 3f);
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScene = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex == totalNumberOfScene)
            nextSceneIndex = 0; //If we have 1 scene we start at index 0 so then it would be 1 1 which means we already at max
        else
            SceneManager.LoadScene(nextSceneIndex);
    }
}
