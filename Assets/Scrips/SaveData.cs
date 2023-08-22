using System;
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
     public TMP_Text animalName;
     
    public mearchAnimal associatedAnimal;
    private int _animalStars;
   
 

    public void Initialize(mearchAnimal animal)
    { associatedAnimal = animal;
       GetComponent<Image>().sprite = animal.MearchAnimalImage; 
      
       
    }
    

    private void Start()
    {
        animalName.fontSize = 70;
        animalName.color = Color.red;
    
        _animalStars = associatedAnimal.Star * 10;
        animalName.text = _animalStars.ToString();

        
       

    }

    public void OnButtonClick()
    {
        
    }
}

