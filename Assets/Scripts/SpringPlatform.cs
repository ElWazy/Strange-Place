using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Its Collide");
    }
}
