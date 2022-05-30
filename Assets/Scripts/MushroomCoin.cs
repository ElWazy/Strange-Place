using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null) {
            playerInventory.MushroomsCollected();
            gameObject.SetActive(false);
        }
    }
}
