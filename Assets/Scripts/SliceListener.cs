using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SliceListener : MonoBehaviour
{
    public Slicer slicer;
    private void OnTriggerEnter(Collider other)
    {
        if((velocity > 0.4 && transform.TransformDirection(transform.position - previous).x < -0.0001 && !ModifierManager.instance.dullBlade) ||
            (velocity > 0.6 && transform.TransformDirection(transform.position - previous).x < -0.003 && ModifierManager.instance.dullBlade))
        {
            slicer.isTouched = true;
            if (other.tag == "ShouldBeSliced")
            {
                var sliceSoundEffect = this.GetComponent<AudioSource>();
                sliceSoundEffect.Play();
            }
        }
        else
        {
            other.tag = "none";
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 opposite = -rb.velocity * 3;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(opposite);
        }
        
    }
    Vector3 previous = new Vector3(0, 0, 0);
    float velocity = 0;
     
    void Update()
    {
        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;
    }
}
