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
    public Image _starIcon;
    private int _animalStars;
    private Image battleAnimalImage1;
    private Image battleAnimalImage2;
    private Image battleAnimalImage3;
 

    public void Initialize(mearchAnimal animal)
    { associatedAnimal = animal;
       GetComponent<Image>().sprite = animal.MearchAnimalImage; 
      
       
    }
    public Image FindImageByName(string name)
    {
        return FindObjectOfType<Image>();
    }

    public void Awake()
    {
        
    }

    private void Start()
    {
        animalName.fontSize = 70;
        animalName.color = Color.red;
    
        _animalStars = associatedAnimal.Star * 10;
        animalName.text = _animalStars.ToString();

        // Now you can use the assigned references
       

    }

    public void OnButtonClick()
    {
        
    }
}

