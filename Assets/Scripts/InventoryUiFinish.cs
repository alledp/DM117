using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUiFinish : MonoBehaviour
{
    public TextMeshProUGUI itemsText;
    public PlayerInventory playerInventory;


    // Start is called before the first frame update
    void Start()
    {
        itemsText = GetComponent<TextMeshProUGUI>();

        itemsText.text = playerInventory.getNumberOfItems().ToString();
    }

}
