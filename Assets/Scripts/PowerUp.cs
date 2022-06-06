using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Movement player = other.GetComponent<Movement>();

            player.speed *= 2;
            gameObject.SetActive(false);
        }
    }
}
