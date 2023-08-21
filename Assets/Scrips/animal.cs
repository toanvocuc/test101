using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class animal : MonoBehaviour
{
    public String animalName;
    public int animalId;
    public Sprite animalSprite;
    public TMP_Text nameHolder;
    public Image animalImage;
    public Button animalButton;
    public Button conFirmButton;
    private AnimalManager _animalManager;
    public Image _chosenImage;
    public Image _secondImage;
    public Image _Mearch3image;
    private void Awake()
    {
        _animalManager = FindObjectOfType<AnimalManager>();
        
    }

    private void Start()
    {
        nameHolder.text = "chose the dad";
        animalImage.sprite = animalSprite; 
        conFirmButton.gameObject.SetActive(false);
    }

    public void OnClickAnimal()

    {
        int clickNum = _animalManager.GetOnClickNum();
        _animalManager.SetChosenAnimal(this);
        
        SoundManager.Instance.PlaySound("AnimalClick");
        
        nameHolder.text = animalName;
        Debug.Log("clicknumb"+clickNum);
        if (SceneSwitcher.Instance.GameMode)
        {
            if (clickNum == 1)
            {     
                nameHolder.text = "chose the mom";
                _secondImage.sprite = animalImage.sprite;
                conFirmButton.gameObject.SetActive(true);
                nameHolder.text = animalName;
            }
            else
            {
                _chosenImage.sprite = animalImage.sprite;
                conFirmButton.gameObject.SetActive(true); 
           
            }
        }
        else
        {
            if (clickNum == 1)
            {     
                nameHolder.text = "chose the mom";
                _secondImage.sprite = animalImage.sprite;
                conFirmButton.gameObject.SetActive(true);
                nameHolder.text = animalName;
            }
            if(clickNum<1)
            {
                _chosenImage.sprite = animalImage.sprite;
                conFirmButton.gameObject.SetActive(true); 
           
            }

            if (clickNum > 1)
            {
                _Mearch3image.sprite = animalImage.sprite;
                conFirmButton.gameObject.SetActive(true);
                
            }
        }
       

       
       
        
    }
}
    

