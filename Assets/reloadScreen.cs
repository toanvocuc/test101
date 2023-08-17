using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScreen : MonoBehaviour
{public static  reloadScreen Instance;
    public GameObject MenuScreen;
    public GameObject GameplayScreen;
    public bool _reLoad= false;
    private void Awake()
    {
        Instance = this;
      _reLoad = false;
    }

    public void ResetScene()
    
    { 
        _reLoad= true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        MenuScreen.SetActive(false);
        GameplayScreen.SetActive(true);
    }
    
}
