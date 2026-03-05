using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AristoOutput : MonoBehaviour
{
    [SerializeField] private TMP_Text congratsText;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image firstNameImage;
    [SerializeField] private List<Image> lastNameImages;
    
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Set(string pseudo, FirstNameSO firstName, List<LastNameSO> lastNames)
    {
        foreach (Image image in lastNameImages)
        {
            image.gameObject.SetActive(false);
        }
        
        congratsText.text = $"Sincères félicitations {pseudo} pour votre ascension sociale.";

        string result = $"<size=70><color=yellow>{firstName.name}</color></size>";
        int score = 0;

        int i = 0;
        
        foreach (LastNameSO lastName in lastNames)
        {
            if (lastName.Particule.Contains('\''))
            {
                result += $" {lastName.Particule}<size=70><color=yellow>{lastName.name}</color></size>";
            }
            else
            {
                result += $" {lastName.Particule} <size=70><color=yellow>{lastName.name}</color></size>";
            }

            score += lastName.score;
            lastNameImages[i].sprite = lastName.Image;
            lastNameImages[i].gameObject.SetActive(true);
            i++;
        }
        
        resultText.text = result;
        
        scoreText.text = $"Votre score généalogique : <size=70><color=yellow>{firstName.score + score}</color></size>";

        firstNameImage.sprite = firstName.Image;
    }
}