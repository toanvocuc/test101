using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmClick : MonoBehaviour
{
    public AnimalManager _animalManager;

    private void Awake()
    {
        GameObject animalManagerObject = GameObject.FindWithTag("AnimalManager");
        _animalManager = animalManagerObject.GetComponent<AnimalManager>();
    }

    public void OnClickAnimalManager()
    {    SoundManager.Instance.PlaySound("ConfirmButtonClick");
        _animalManager.AddAnimal();
    }
}