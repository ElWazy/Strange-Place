using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEntity : MonoBehaviour
{
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("End")) {
            transform.position = originalPosition;
        }
    }
}
