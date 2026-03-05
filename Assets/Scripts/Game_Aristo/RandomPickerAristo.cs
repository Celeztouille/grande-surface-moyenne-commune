using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomPickerAristo : MonoBehaviour
{
    [SerializeField] private NamesList namesList;
    [SerializeField] private TMP_InputField pseudoInputField;
    [SerializeField] private TMP_InputField depInputField;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private AristoOutput outputScreen;

    private Gender currentGender = Gender.F;

    public void SetGenderToMale(bool value) => currentGender = value ? Gender.M : currentGender;
    public void SetGenderToFemale(bool value) => currentGender = value ? Gender.F : currentGender;
    
    private int ConvertToSeed(string value)
    {
        int seed = 0;
        foreach (char c in value)
        {
            seed += c;
        }
        return seed;
    }

    public void Go()
    {
        if (string.IsNullOrEmpty(pseudoInputField.text))
        {
            errorText.text = "Il est prohibé de ne pas mentionner son pseudo.";
            errorText.gameObject.SetActive(true);
            return;
        }
        if (string.IsNullOrEmpty(depInputField.text))
        {
            errorText.text = "Il est prohibé de ne pas mentionner son département.";
            errorText.gameObject.SetActive(true);
            return;
        }

        int seed = ConvertToSeed(depInputField.text + pseudoInputField.text.ToLower());
        
        Random.InitState(seed);
        int particlesCount = Random.Range(2, 5);

        FirstNameSO firstName = namesList.GetRandomFirstName(seed, currentGender);

        List<LastNameSO> lastNames = namesList.GetRandomLastNames(seed, particlesCount);
        string pseudo = pseudoInputField.text;
        
        errorText.gameObject.SetActive(false);
        pseudoInputField.text = "";
        depInputField.text = "";
        outputScreen.Set(pseudo, firstName, lastNames);
        outputScreen.Open();
    }
}