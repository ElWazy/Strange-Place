using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeGoal : MonoBehaviour
{
    public UnityEvent OnGoaled;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Moveable")) {
            OnGoaled.Invoke();
        }
    }
}
