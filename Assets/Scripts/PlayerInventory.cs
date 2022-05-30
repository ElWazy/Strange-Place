using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int mushrooms { get; private set; }
    public UnityEvent<PlayerInventory> OnMushroomCollected;

    public void MushroomsCollected()
    {
        mushrooms++;
        OnMushroomCollected.Invoke(this);
    }
}
