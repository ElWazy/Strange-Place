using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject coins;
    void Start()
    {
       coins.SetActive(false);
    }

    public void SpawnAmulet()
    {
       coins.SetActive(true);
    }
}
