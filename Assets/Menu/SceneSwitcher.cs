using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName; 
    public AudioSource audioSource;
    public static SceneSwitcher Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        audioSource.Stop();
    }

    public void SwitchScene()
    { if (audioSource != null)
        {
            audioSource.Play();
           
        }
        StartCoroutine(ActivateImageDelayed());
         
    }
    private IEnumerator ActivateImageDelayed()
    {    
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(targetSceneName);
    }
}