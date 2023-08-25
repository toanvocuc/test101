using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSavedData : MonoBehaviour
{
    public mearchAnimal SavedAnimal;
    private List<int> _savedIds = new List<int>();
    private List<mearchAnimal> _savedAnimals = new List<mearchAnimal>();
    public GameObject buttonPrefab;
    public Transform spawnParent;

    void Start()
    {
        _savedIds = SaveButton.Instance._savedAnimalIds;
        Debug.Log(_savedIds.Count+"ddd");
        SaveButton.Instance.LoadSavedAnimalIds();

        if (_savedIds.Count == 0)
        {
            Debug.Log("No saved animals found.");
            return;
        }

        foreach (int savedAnimalId in _savedIds)
        {
            SavedAnimal = AnimalManager.Instance.GetAnimalById(savedAnimalId);
            if (SavedAnimal != null)
            {
                _savedAnimals.Add(SavedAnimal);
                SpawnButtonWithSprite(SavedAnimal.MearchAnimalImage);
            }
            else
            {
                Debug.LogWarning("Animal not found for ID: " + savedAnimalId);
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
}
