
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SaveButton : MonoBehaviour
{
    public static SaveButton Instance;
    public GameObject saveScreen;
    public GameObject menuScreen;
    public GameObject comBatScreen;
    //list save
    private mearchAnimal _cureentanimal;
    private List<int> _savedAnimalIds = new List<int>();
    private List<mearchAnimal> savedAnimals = new List<mearchAnimal>();
    //save
    public GameObject buttonPrefab;
    public Transform spawnParent;
    public mearchAnimal SavedAnimal;
    //combat
    public Sprite battleStar;
    // public Image animalInfoImage;
    // public TMP_Text animalInfoName;
    // public GameObject star;
    
    public Transform spawnCombatParent;
    private void Awake()
    {
        Instance = this;
    }

    public void OnSaveButton()
    {
        mearchAnimal saveAnimal = AnimalManager.Instance.CurrentManimal();
        int animalId = saveAnimal.Id;

        LoadSavedAnimalIds();

        if (!_savedAnimalIds.Contains(animalId))
        {    PreventSaveButton();
            _savedAnimalIds.Add(animalId);
            SaveAnimalIds();
            Debug.Log("Added new animal ID to the list.");
        }
        else
        {
            Debug.Log("Matching animal ID found.");
            PreventSaveButton();

        }
    }

    public void PreventSaveButton()
    {
        Button buttonToDisable = GetComponent<Button>();
        buttonToDisable.interactable = false;
        ColorBlock colors = buttonToDisable.colors;
        colors.normalColor = new Color(0.7f, 0.7f, 0.7f, 1.0f);
        buttonToDisable.colors = colors;
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

    public void OnLoadData()//for save menu
    {
        saveScreen.SetActive(true);
        menuScreen.SetActive(false);
        LoadSavedAnimalIds();
        SoundManager.Instance.PlaySound("ConfirmButtonClick");
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

        
        
    }

    private void SpawnButtonWithSprite(Sprite sprite)// for save menu 
    {    
        
        GameObject newButton = Instantiate(buttonPrefab, spawnParent);
        Image buttonImage = newButton.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = sprite;
        }
    }
    
    private void SpawnButtonWithAnimal(mearchAnimal animal)//for combat
    {
        GameObject newButton = Instantiate(buttonPrefab, spawnCombatParent);
        SaveData animalButton = newButton.AddComponent<SaveData>();

        // Pass the required references to the SaveData component
        animalButton.animalName = newButton.GetComponentInChildren<TMP_Text>();

        // Initialize the associated animal
        animalButton.Initialize(animal);
    }

    public void OnLoadDataForBattle()// for combat
    {
        saveScreen.SetActive(false);
        menuScreen.SetActive(false);
        comBatScreen.SetActive(true);
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
            {
                savedAnimals.Add(SavedAnimal);
                SpawnButtonWithAnimal(SavedAnimal);
            }
        }

       
    }
    

    public List<mearchAnimal> GetSavedAnimals()
    {
        return savedAnimals;
    }
    
}

    


   

