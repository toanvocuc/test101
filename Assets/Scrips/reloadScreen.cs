using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScreen : MonoBehaviour
{public static  reloadScreen Instance;
    public bool _reLoad= false;
    private void Awake()
    {
        Instance = this;
      
    }

    private void Start()
    {
        _reLoad = false;
    }

    public void ResetScene()
    
    { 
        _reLoad = true;
        // Clear the saved GameMode value
        // PlayerPrefs.DeleteKey("GameMode");
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
    }
    
}
