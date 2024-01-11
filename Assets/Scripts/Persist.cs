using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Persist : MonoBehaviour
{
    private Scene homeScene;
    public bool alive;
    void Start()
    {
        homeScene = SceneManager.GetActiveScene();
        alive = true;
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene() != homeScene)
        {
            
        }
    }
}
