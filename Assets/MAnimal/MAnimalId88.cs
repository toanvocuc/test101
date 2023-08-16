using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Mearch Animal",menuName = "MAnimal")]
[Serializable]
public class mearchAnimal : ScriptableObject
{
  public int Id;
  public string MearchAnimalName;
  public int Star;
  public string Description;
  public Sprite MearchAnimalImage;

}
