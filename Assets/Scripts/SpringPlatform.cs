using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Its Collide");
    }
}
