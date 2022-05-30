using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI mushroomText;
    void Start()
    {
       mushroomText = GetComponent<TextMeshProUGUI>(); 
    }

    public void UpdateMushroomText(PlayerInventory playerInventory)
    {
       mushroomText.text = playerInventory.mushrooms.ToString();
    }
}
