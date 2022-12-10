using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SliceListener : MonoBehaviour
{
    public Slicer slicer;
    public TextMeshPro text;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro text4;
    private void OnTriggerEnter(Collider other)
    {
        if(velocity > 0.8 && transform.TransformDirection(transform.position - previous).x < -0.005)
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
            Debug.Log("miss");
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
        

        text.text = velocity.ToString("0.00");
        text2.text = transform.TransformDirection(transform.position - previous).x.ToString("0.0000");
        text3.text = transform.TransformDirection(transform.position - previous).y.ToString("0.0000");
        text4.text = transform.TransformDirection(transform.position - previous).z.ToString("0.0000");
        previous = transform.position;
    }
}
