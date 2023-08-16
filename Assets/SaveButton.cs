using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{   
    
    
    String SaveScreen="SaveAnimalScreen";
    public TMP_Text ManimalName;
    public Image ManimalImage;
    public Image FirstImage;
    private mearchAnimal _cureentanimal;
        
    private void Awake()
    {
       // _cureentanimal = ScriptableObject.CreateInstance<mearchAnimal>();
        
    }

    private void Start()
    {    string activeSceneName = SceneManager.GetActiveScene().name;
        Debug.Log(activeSceneName);
        if (activeSceneName == SaveScreen)
        {
            OnLoadData();
        }
        
        
    }

    public void OnSaveButton()
    {
        mearchAnimal saveAnimal = AnimalManager.Instance.CurrentManimal();
        int animalID = saveAnimal.Id;
        PlayerPrefs.SetInt("SavedAnimalID", animalID);
        PlayerPrefs.Save();
        


    }
    
    private void OnLoadData()
    {
        if (PlayerPrefs.HasKey("SavedAnimalID"))
        {
            int savedAnimalID = PlayerPrefs.GetInt("SavedAnimalID");
            Debug.Log("Saved Animal ID: " + savedAnimalID);

            
          Debug.Log( AnimalManager.Instance.GetAnimalById(savedAnimalID));  
           
           
            
           

        }
    }

}
   

