using System.Collections.Generic;
using UnityEngine;

public class ShopList : MonoBehaviour
{
    [SerializeField] private List<ShopSO> shops;

    public int MaxRange => shops.Count;

    public ShopSO GetShopAtIndex(int index)
    {
        if (index >= shops.Count)
        {
            Debug.LogError("[ShopList] OutOfRange");
        }

        return shops[index];
    }
}
