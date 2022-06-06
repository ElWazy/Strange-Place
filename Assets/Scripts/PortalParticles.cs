using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalParticles : MonoBehaviour
{

    public GameObject particle;
    private int mushroomsRequired;


    void Start(){
        particle.SetActive(false);
    }


    public void ActivatePortal(PlayerInventory playerInventory)
    {
       mushroomsRequired = playerInventory.mushrooms;
       if (mushroomsRequired == 6){
            particle.SetActive(true);
       }
    }

    


}
