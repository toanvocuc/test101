using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance;
    private List<animal> _chosenOne = new List<animal>();
    private List<int> _idAnimal= new List<int>();
    public List<mearchAnimal> mearchanimals = new List<mearchAnimal>();
    
    public TMP_Text mAnimalDescription;
    public TMP_Text mAnimalname;
    
    public Image chosenImage;
    public Image secondImage;
    public Image mearch3Image;
    public Image thirtImage;
    
    public Button confirmButton;
    public Button resetButton;
    public Button saveButton;
    public Button backToMenu;
    private animal _chosenAnimal;
    
  
    public Animator dadAnimator;
    public Animator momAnimator;
    public Animator mearch3Animator;

    public GameObject ScrollView;
    public GameObject StarHolder;
    
    private mearchAnimal _currentMearchAnimal;
    public StarManager starManager;

    private int _onClickNumber;
    private int _sum ;

    
    
    
    private void Start()
    {
        secondImage.gameObject.SetActive(false);
        SoundManager.Instance.PlaySound("BackGroundMusic");
    }

    private void Awake()
    {
        if (Instance != null)
        {
           Destroy(this);
           return;
        }

        Instance = this;
       

    }

    public void AddAnimal() // game mode true :phase1-3/ game mod false phase 1-2-4-3
    {   _onClickNumber++;
        if (_chosenAnimal == null) return;
        _chosenOne.Add(_chosenAnimal);
        _idAnimal.Add(_chosenAnimal.animalId);

        if (_onClickNumber < 2)
        {
            confirmButton.gameObject.SetActive(false);
            dadAnimator.Play("TranferPict");
                
            chosenImage.sprite = _chosenAnimal.animalSprite;
            _chosenAnimal.gameObject.SetActive(false);
            mAnimalname.text = "chose the mom";
        }

        if (_onClickNumber==2)
        {
            if (SceneSwitcher.Instance.GameMode)
            {
                SoundManager.Instance.StopSound("BackGroundMusic");
                SoundManager.Instance.PlaySound("Phase3Music");
              
                Phase3Tranfer();
                // mAnimalname.text = "Generating:....";
                CalculateSumOfIds();
                Debug.Log("sum later:"+_sum);
                FindIdMAnimal();
                _chosenAnimal.gameObject.SetActive(false);
            }
            else
            
            {   _chosenAnimal.gameObject.SetActive(false);
                Phase4Tranfer();
            }
            
        }

        if (_onClickNumber > 2)
            
        {   CalculateSumOfIds();
            FindIdMAnimal();
            Debug.Log("sum later:"+_sum);
            SoundManager.Instance.StopSound("BackGroundMusic");
            SoundManager.Instance.PlaySound("Phase3Music");
            mearch3Animator.Play("Mearch");
            dadAnimator.Play("mearch");
            momAnimator.Play("Fashe4Mearch");
            Phase3Tranfer();
        }

        if (_onClickNumber != 2 && _onClickNumber != 1) return;
        secondImage.gameObject.SetActive(true);
        momAnimator.Play("tranfer");
    }

    private void CalculateSumOfIds()
    {
        _sum = 0;
        foreach (var id in _idAnimal)
        {
            _sum += id; 
        }
    }
  
    public void SetChosenAnimal(animal chosenAnimal)
    {
        _chosenAnimal = chosenAnimal;
    }

    public int GetOnClickNum()
    {
        return _onClickNumber;
    }

    private void Phase3Tranfer()
    {   
        ScrollView.SetActive(false);
        confirmButton.gameObject.SetActive(false);

      
        dadAnimator.Play("mearch");
        momAnimator.Play("Mearch");
                
        Destroy(chosenImage,2f);
        Destroy(secondImage,2f);
        StartCoroutine(ActivateImageDelayed());

    }

    private void Phase4Tranfer()
    {
        confirmButton.gameObject.SetActive(false);
        momAnimator.Play("Tofash4");
        mearch3Image.gameObject.SetActive(true);
        mearch3Animator.Play("Idle");
       
    }
    private IEnumerator ActivateImageDelayed()
    {
        yield return new WaitForSeconds(2f);
        mearch3Image.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(true);
        backToMenu.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        thirtImage.gameObject.SetActive(true);
        mAnimalDescription.gameObject.SetActive(true);
        StarHolder.SetActive((true));
        starManager.AddStars();
    }

    private void FindIdMAnimal()
    {
        foreach (var t in mearchanimals)
        {
            if (_sum == t.Id)
            {    Debug.Log(t.Id);
                thirtImage.sprite = t.MearchAnimalImage;
                mAnimalDescription.text = t.Description;
                mAnimalname.text = t.MearchAnimalName;
            }
        }
        
        
    }

    public mearchAnimal CurrentManimal( )
    {
        for (int i=0;i<mearchanimals.Count;i++)
        {
            if (_sum == mearchanimals[i].Id)
            
                _currentMearchAnimal=  mearchanimals[i] ;
        }

        return _currentMearchAnimal;
    }

    public mearchAnimal GetAnimalById(int id)
    {
       
        for (int i = 0; i < mearchanimals.Count; i++)
        {
            if (id == mearchanimals[i].Id)
                return mearchanimals[i];
        }

        return null; 
    }
    







}