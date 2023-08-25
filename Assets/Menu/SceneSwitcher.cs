using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    
    public AudioSource audioSource;
    public static SceneSwitcher Instance;
    public GameObject GamePlayscreen;
    public GameObject MenuScreen;
    public bool GameMode ;

    private void Awake()
    { audioSource.Stop();
        Instance = this;
        GameMode = PlayerPrefs.GetInt("GameMode", 0) == 1;
        
        
    }

    private void Start()
    {
        audioSource.Stop();
        
        
        if (reloadScreen.Instance._reLoad)
        {
            MenuScreen.SetActive(false);
            GamePlayscreen.SetActive(true); 
        }
        else
        {
            return;
        }
    }

    public void SwitchScene()
    { if (audioSource != null)
        {
            audioSource.Play();
        }
        StartCoroutine(ActivateImageDelayed());
        GameMode = true;
        // Save the GameMode value
        PlayerPrefs.SetInt("GameMode", GameMode ? 1 : 0);

    }
    private IEnumerator ActivateImageDelayed()
    {    
        yield return new WaitForSeconds(2f);
        MenuScreen.SetActive(false);
        GamePlayscreen.SetActive(true);
        
    }
}