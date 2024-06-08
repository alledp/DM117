using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfItems { get; private set; }

    public TextMeshProUGUI itemsText;

//    public UnityEvent<PlayerInventory> OnItemsCollected;

    public void ItemsCollected()
    {
        NumberOfItems++;
        itemsText.text = NumberOfItems.ToString();
//        OnItemsCollected.Invoke(this);
    }

    public int getNumberOfItems()
    {
        return NumberOfItems;
    }
}
