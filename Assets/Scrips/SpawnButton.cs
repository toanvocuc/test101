using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    public ScrollRect scrollView; 
    
    public GameObject buttonPrefab;

    public void AddButton()
    {
        GameObject newButton = Instantiate(buttonPrefab, scrollView.content);
    } 
}
