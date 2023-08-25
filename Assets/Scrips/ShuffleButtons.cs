using UnityEngine;
using UnityEngine.UI;

public class ShuffleButtonsInScrollView : MonoBehaviour
{
   
    public RectTransform content;

    private void Start()
    {
        ShuffleButtonPositions();
    }

    public void ShuffleButtonPositions()
    {
        int buttonCount = content.childCount;
        for (int i = buttonCount - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Transform button = content.GetChild(i);
            button.SetSiblingIndex(randomIndex);
        }
    }
}