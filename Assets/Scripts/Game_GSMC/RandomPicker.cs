using TMPro;
using UnityEngine;

public class RandomPicker : MonoBehaviour
{
    [SerializeField] private TownList townList;
    [SerializeField] private ShopList shopList;
    [SerializeField] private TMP_InputField pseudoInputField;
    [SerializeField] private TMP_InputField depInputField;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private Output outputScreen;

    private string pseudo;
    
    public void SetPseudo(string value) => pseudo = value;
    
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
            errorText.text = "Tu dois rentrer ton pseudo :emoji_fâché:";
            errorText.gameObject.SetActive(true);
            return;
        }
        if (string.IsNullOrEmpty(depInputField.text))
        {
            errorText.text = "Tu dois rentrer ton numéro de département :emoji_fâché:";
            errorText.gameObject.SetActive(true);
            return;
        }

        int seed = ConvertToSeed(depInputField.text + pseudoInputField.text.ToLower());
        Random.InitState(seed);

        Town town = townList.GetTownAtIndex(Random.Range(0, townList.MaxRange));
        ShopSO shop = shopList.GetShopAtIndex(Random.Range(0, shopList.MaxRange));
        string pseudo = pseudoInputField.text;
        
        errorText.gameObject.SetActive(false);
        pseudoInputField.text = "";
        depInputField.text = "";
        outputScreen.Set(pseudo, town, shop);
        outputScreen.Open();
    }
}
