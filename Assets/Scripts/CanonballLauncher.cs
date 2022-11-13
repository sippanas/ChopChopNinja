using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonballLauncher : MonoBehaviour
{
    [SerializeField]
    public GameObject projectile;
    [SerializeField]
    public float launchVelocity = 700f;
    [SerializeField]
    [Range(10, 100)]
    private int LinePoints = 25;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    private float TimeBetweenPoints = 0.1f;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            GameObject canonball = Instantiate(projectile, transform.position,
                                                     transform.rotation);
            canonball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                 (0, launchVelocity, 0));
        }
        
    }
}
