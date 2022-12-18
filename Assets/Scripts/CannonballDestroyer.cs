using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // If a ball isn't sliced it should have the "ShouldBeSliced" tag
        if(this.tag == "ShouldBeSliced" && other.tag == "Destroyer")
        {
            ComboManager.instance.Miss();
            Destroy(this);
        }
        // Otherwise destroy the sliced pieces
        else if(other.tag == "Destroyer") 
        {
            Destroy(this.gameObject);
        }
    }
}
