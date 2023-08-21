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
    { if (audioSource != null)
        {
            audioSource.Play();
           
        }
        StartCoroutine(ActivateImageDelayed());
        SceneSwitcher.Instance.GameMode = false;

    }
    private IEnumerator ActivateImageDelayed()
    {    
        yield return new WaitForSeconds(2f);
        MenuScreen.SetActive(false);
        GamePlayscreen.SetActive(true);
        
    }
}
