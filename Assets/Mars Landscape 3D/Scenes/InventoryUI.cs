using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    public TextMeshProUGUI itemsText;

    // Start is called before the first frame update
    void Start()
    {
        itemsText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateItemsText(PlayerInventory playerInventory)
    {
        itemsText.text = playerInventory.NumberOfItems.ToString();
    }

}
