using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnClicksaveAnim : MonoBehaviour
{
   
    [SerializeField] private TMP_Text animalName;
    private mearchAnimal _savedAnimal;
    public void OnViewSaved()
    {
        List<mearchAnimal> savedAnimalsList = SaveButton.Instance.GetSavedAnimals();
        int numberOfChildren = transform.childCount; 
    }
}
