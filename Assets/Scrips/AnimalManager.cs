using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance;
    private List<animal> _chosenOne = new List<animal>();
    private List<int> _idAnimal= new List<int>();
    public List<mearchAnimal> mearchanimals = new List<mearchAnimal>();
    
    public TMP_Text MAnimalDescription;
    public TMP_Text MAnimalname;
    
    public Image _chosenImage;
    public Image _secondImage;
    
    public Button confirmButton;
    public Button resetButton;
    public Button SaveButton;
    public Button backToMenu;
    private animal _chosenAnimal;
    public Image _thirtImage;
  
    public Animator dadAnimator;
    public Animator momAnimator;

    public GameObject ScrollView;
    
    private mearchAnimal _currentMearchAnimal;
     

    private int _onClickNumber;
    private int _sum = 0;

    public GameObject StarHolder;


    public StarManager starManager;
    
    
    private void Start()
    {
        _secondImage.gameObject.SetActive(false);
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

    public void AddAnimal()
    {   _onClickNumber++;
        if (_chosenAnimal == null) return;
        _chosenOne.Add(_chosenAnimal);
        _idAnimal.Add(_chosenAnimal.animalId);

        if (_onClickNumber < 2)
        {
            confirmButton.gameObject.SetActive(false);
            dadAnimator.Play("TranferPict");
                
            _chosenImage.sprite = _chosenAnimal.animalSprite;
            _chosenAnimal.gameObject.SetActive(false);
        }

        if (_onClickNumber>=2)
        {    SoundManager.Instance.StopSound("BackGroundMusic");
            SoundManager.Instance.PlaySound("Phase3Music");
            Phase3Tranfer();
            CalculateSumOfIds();
            Debug.Log("sum later:"+_sum);
            FindIdMAnimal();
        }

        if (_onClickNumber != 2 && _onClickNumber != 1) return;
        _secondImage.gameObject.SetActive(true);
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
                
        Destroy(_chosenImage,2f);
        Destroy(_secondImage,2f);
        StartCoroutine(ActivateImageDelayed());

    }
    private IEnumerator ActivateImageDelayed()
    {
        yield return new WaitForSeconds(2f);
        SaveButton.gameObject.SetActive(true);
        backToMenu.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        _thirtImage.gameObject.SetActive(true);
        MAnimalDescription.gameObject.SetActive((true));
        StarHolder.SetActive((true));
        starManager.AddStars();
    }

    private void FindIdMAnimal()
    {
        foreach (var t in mearchanimals)
        {
            if (_sum == t.Id)
            {    Debug.Log(t.Id);
                _thirtImage.sprite = t.MearchAnimalImage;
                MAnimalDescription.text = t.Description;
                MAnimalname.text = t.MearchAnimalName;
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