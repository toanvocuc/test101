using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    private AnimalManager _animalManager;
    // public List<mearchAnimal> mearchanimals = new List<mearchAnimal>();
    public List<GameObject> stars = new List<GameObject>();
    public Animator starAnimator;
    private void Awake()
    {
        _animalManager = FindObjectOfType<AnimalManager>();
        
    }

    public void AddStars()
    {
        var currentManimal = _animalManager.CurrentManimal();
        switch (currentManimal.Star)
        {
            case 1:
               starAnimator.Play("1star");
               SoundManager.Instance.PlaySound("StarSound");
                break;
            case 2:
                starAnimator.Play("2star");
                SoundManager.Instance.PlaySound("StarSound");
                break;
            case 3:
                starAnimator.Play("3star");
                SoundManager.Instance.PlaySound("StarSound");
                break;
            case 4:
                starAnimator.Play("4star");
                SoundManager.Instance.PlaySound("StarSound");
                break;
            case 5:
                starAnimator.Play("5star");
                SoundManager.Instance.PlaySound("StarSound");
                break;
            case 6:
                starAnimator.Play("6star");
                SoundManager.Instance.PlaySound("StarSound");
                break;
            case 7:
                starAnimator.Play("7star");
                SoundManager.Instance.PlaySound("StarSound");
                break;
            case 8:
                starAnimator.Play("8star");
                SoundManager.Instance.PlaySound("StarSound");
                break;
            case 9:
                starAnimator.Play("9star");
                SoundManager.Instance.PlaySound("StarSound");
                break;
            default:
                
                break;
        }

    }

   
    
    
}
 