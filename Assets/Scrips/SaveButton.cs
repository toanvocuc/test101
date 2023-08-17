
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SaveButton : MonoBehaviour
{
    public static SaveButton Instance;
    public GameObject saveScreen;
    public GameObject menuScreen;

    private mearchAnimal _cureentanimal;
    private List<int> _savedAnimalIds = new List<int>();
    private List<mearchAnimal> savedAnimals = new List<mearchAnimal>();

    public GameObject buttonPrefab;
    public Transform spawnParent;
    public mearchAnimal SavedAnimal;

    private void Awake()
    {
        Instance = this;
    }

    public void OnSaveButton()
    {
        mearchAnimal saveAnimal = AnimalManager.Instance.CurrentManimal();
        int animalID = saveAnimal.Id;

        LoadSavedAnimalIds();

        if (!_savedAnimalIds.Contains(animalID))
        {
            _savedAnimalIds.Add(animalID);
            SaveAnimalIds();
            Debug.Log("Added new animal ID to the list.");
        }
        else
        {
            Debug.Log("Matching animal ID found.");
            Button buttonToDisable = GetComponent<Button>();
            buttonToDisable.interactable = false;
            ColorBlock colors = buttonToDisable.colors;
            colors.normalColor = new Color(0.7f, 0.7f, 0.7f, 1.0f);
            buttonToDisable.colors = colors;

        }
    }

    private void LoadSavedAnimalIds()
    {

        string savedData = PlayerPrefs.GetString("SavedAnimalIds", "");
        if (!string.IsNullOrEmpty(savedData))
        {
            _savedAnimalIds = savedData.Split(',').Select(int.Parse).ToList();
        }
    }

    private void SaveAnimalIds()
    {
        string savedData = string.Join(",", _savedAnimalIds.Select(id => id.ToString()).ToArray());
        PlayerPrefs.SetString("SavedAnimalIds", savedData);
        PlayerPrefs.Save();
    }

    public void OnLoadData()
    {
        saveScreen.SetActive(true);
        LoadSavedAnimalIds();
        
        if (_savedAnimalIds.Count == 0)
        {
            Debug.Log("No saved animals found.");
            return;
        }

        foreach (int savedAnimalId in _savedAnimalIds)
        {
            SavedAnimal = AnimalManager.Instance.GetAnimalById(savedAnimalId);
            if (SavedAnimal != null)
            {     savedAnimals.Add(SavedAnimal);
                SpawnButtonWithSprite(SavedAnimal.MearchAnimalImage);

            }
        }

        menuScreen.SetActive(false);
        
    }

    private void SpawnButtonWithSprite(Sprite sprite)
    {    
        
        GameObject newButton = Instantiate(buttonPrefab, spawnParent);
        Image buttonImage = newButton.GetComponent<Image>();
        // newButton.name = 

        if (buttonImage != null)
        {
            buttonImage.sprite = sprite;
        }
    }

    public List<mearchAnimal> GetSavedAnimals()
    {
        return savedAnimals;
    }
}

    


   

