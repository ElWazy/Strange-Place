using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene("Menu");
    }
}
