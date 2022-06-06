using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPowerUp : MonoBehaviour
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
