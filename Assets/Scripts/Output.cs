using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Output : MonoBehaviour
{
    [SerializeField] private TMP_Text congratsText;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image shopImage;
    [SerializeField] private PinSetter pin;
    
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Set(string pseudo, Town town, ShopSO shop)
    {
        congratsText.text = $"Félicitations {pseudo} !";

        if (town.name[0] is 'A' or 'E' or 'É' or 'È' or 'Ê' or 'I' or 'O' or 'U' or 'Y')
        {
            resultText.text = $"Tu es le <size=50><color=yellow>{shop.name.ToUpper()}</color></size> d'<size=50><color=yellow>{town.name.ToUpper()}</color></size>";
        }
        else
        {
            resultText.text = $"Tu es le <size=50><color=yellow>{shop.name.ToUpper()}</color></size> de <size=50><color=yellow>{town.name.ToUpper()}</color></size>";
        }

        scoreText.text = $"Ton score périurbain : <size=50><color=yellow>{shop.score * town.population}</color></size>";

        shopImage.sprite = shop.Image;
        pin.SetPin(town.latitude, town.longitude);

    }
}
