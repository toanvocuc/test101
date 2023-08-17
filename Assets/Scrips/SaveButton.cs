
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SaveButton : MonoBehaviour
{
    public GameObject saveScreen;
    public GameObject menuScreen;
    
    private mearchAnimal _cureentanimal;
    private List<int> savedAnimalIds = new List<int>();
    
    public GameObject buttonPrefab;
    public Transform spawnParent;
    
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
            Button buttonToDisable = GetComponent<Button>();
               buttonToDisable .interactable = false;
            ColorBlock colors = buttonToDisable.colors;
            colors.normalColor = new Color(0.7f, 0.7f, 0.7f, 1.0f); // Gray color
            buttonToDisable.colors = colors;
            
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
    { saveScreen.SetActive(true);
        LoadSavedAnimalIds();

        if (savedAnimalIds.Count == 0)
        {
            Debug.Log("No saved animals found.");
            return;
        }

        foreach (int savedAnimalId in savedAnimalIds)
        {   
            mearchAnimal savedAnimal = AnimalManager.Instance.GetAnimalById(savedAnimalId);
            if (savedAnimal != null)
            {
                SpawnButtonWithSprite(savedAnimal.MearchAnimalImage);
                
                // Debug.Log("Loaded Animal Name: " + savedAnimal.MearchAnimalName);
                // Debug.Log("Loaded Animal id: " + savedAnimal.Id);
                // Debug.Log("Loaded Animal star: " + savedAnimal.Star);
                // Debug.Log("Loaded Animal image" + savedAnimal.MearchAnimalImage.name);

                
            }
        }
        menuScreen.SetActive(false); 
    }
    private void SpawnButtonWithSprite(Sprite sprite)
    {
        GameObject newButton = Instantiate(buttonPrefab, spawnParent);
        Image buttonImage = newButton.GetComponent<Image>();
        
        if (buttonImage != null)
        {
            buttonImage.sprite = sprite;
        }
    }


}

    


   

