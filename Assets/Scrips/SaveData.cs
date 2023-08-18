using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    // public Image animalImage;
    // public TMP_Text animalName;

    public mearchAnimal associatedAnimal;

    public void Initialize(mearchAnimal animal)
    {
        associatedAnimal = animal;
       GetComponent<Image>().sprite = animal.MearchAnimalImage;
        // animalName.text = animal.MearchAnimalName;
    }

    public void OnButtonClick()
    {
        // Display information of the associated animal
        // SaveButton.Instance.DisplayAnimalInfo(associatedAnimal);
    }
}
