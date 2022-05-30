using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuOptions : MonoBehaviour {



    public void Jugar(){
        SceneManager.LoadScene("level1");
    }

    public void Salir(){
        Application.Quit();
    }

    }