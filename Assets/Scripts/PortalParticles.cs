using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalParticles : MonoBehaviour
{

    public GameObject particle;

    void Start(){

        particle.SetActive(false);
    }


    void OnTriggerEnter(Collider collider)
    {
        particle.SetActive(true);
    }
    


}
