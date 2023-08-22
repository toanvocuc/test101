
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
    //list save
    public List<int> _savedAnimalIds = new List<int>();
    private List<mearchAnimal> _savedAnimals = new List<mearchAnimal>();
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

    public void LoadSavedAnimalIds()
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

    /// <summary>
    /// oly for save button ;
    /// </summary>
    public void OnLoadData() //for load saved screen
    {
        saveScreen.SetActive(true);
        menuScreen.SetActive(false);

        SoundManager.Instance.PlaySound("ConfirmButtonClick");
        LoadSavedAnimalIds();
    }
}

    


   

