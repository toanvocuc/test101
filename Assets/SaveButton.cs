using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    public TMP_Text ManimalName;
    public Image ManimalImage;
    public Image FirstImage;
    private mearchAnimal _cureentanimal;
    private List<int> savedAnimalIds = new List<int>();
   
        
    private void Awake()
    {
       // _cureentanimal = ScriptableObject.CreateInstance<mearchAnimal>();
        
    }

    private void Start()
    {  
        
        
    }

    public void OnSaveButton()
    {
        mearchAnimal saveAnimal = AnimalManager.Instance.CurrentManimal();
        int animalID = saveAnimal.Id;

        LoadSavedAnimalIds();

        if (!savedAnimalIds.Contains(animalID))
        {
            savedAnimalIds.Add(animalID);
            SaveAnimalIds();
            Debug.Log("Added new animal ID to the list.");
        }
        else
        {
            Debug.Log("Matching animal ID found.");
            // Perform action for matching ID
        }
    }

    private void LoadSavedAnimalIds()
    {
        string savedData = PlayerPrefs.GetString("SavedAnimalIds", "");
        if (!string.IsNullOrEmpty(savedData))
        {
            savedAnimalIds = savedData.Split(',').Select(int.Parse).ToList();
        }
    }

    private void SaveAnimalIds()
    {
        string savedData = string.Join(",", savedAnimalIds.Select(id => id.ToString()).ToArray());
        PlayerPrefs.SetString("SavedAnimalIds", savedData);
        PlayerPrefs.Save();
    }
    
    public void OnLoadData()
    {    LoadSavedAnimalIds();

        foreach (int savedAnimalId in savedAnimalIds)
        {
            // Perform actions for each saved animal ID
            Debug.Log("Saved Animal ID: " + savedAnimalId);

            // Retrieve the corresponding mearchAnimal based on the saved ID
            mearchAnimal savedAnimal = AnimalManager.Instance.GetAnimalById(savedAnimalId);
            if (savedAnimal != null)
            {
                // Perform additional actions with the savedAnimal
                Debug.Log("Loaded Animal Name: " + savedAnimal.MearchAnimalName);

                // Display the animal image and name, if desired
                // ManimalImage.sprite = savedAnimal.MearchAnimalImage;
                // ManimalName.text = savedAnimal.MearchAnimalName;
            }
        }
       
    }

}

    


   

