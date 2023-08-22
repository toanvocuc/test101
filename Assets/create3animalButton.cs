using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create3animalButton : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject GamePlayscreen;
    public GameObject MenuScreen;
   
    private void Start()
    {
        audioSource.Stop();
    }
    public void SwitchScene()
    {  if (audioSource != null)
        {
            audioSource.Play();
        }
        StartCoroutine(ActivateImageDelayed());
        
        // Set the GameMode to false
        SceneSwitcher.Instance.GameMode = false;
        // Save the GameMode value
        PlayerPrefs.SetInt("GameMode", SceneSwitcher.Instance.GameMode ? 1 : 0);
    }
    private IEnumerator ActivateImageDelayed()
    {    
        yield return new WaitForSeconds(2f);
        MenuScreen.SetActive(false);
        GamePlayscreen.SetActive(true);
        
    }
}
