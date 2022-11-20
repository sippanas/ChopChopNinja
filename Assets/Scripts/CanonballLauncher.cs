using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonballLauncher : MonoBehaviour
{
    [SerializeField]
    public GameObject projectile;
    [SerializeField]
    public float launchVelocity = 1000f;
    [SerializeField]
    [Range(10, 100)]
    private int LinePoints = 25;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    private float TimeBetweenPoints = 0.1f;
    [SerializeField]
    AudioSource audioData;
    [SerializeField]
    AudioClip clip;

    float elapsed = 0;
    float timeBasedOnDifficulty = 0f;

    void Start()
    {
        var difficultyIndex = DifficultyManager.Instance.CurrentDifficultyIndex;
        timeBasedOnDifficulty = (float)difficultyIndex;
    }

    void Update()
    {
        // TODO: Implement dynamic difficulty

        elapsed += Time.deltaTime;
        var timeToElapse = (1.2f - (timeBasedOnDifficulty / 10f));

        if (elapsed >= timeToElapse)
        {
            elapsed = elapsed % timeToElapse;
            audioData.clip = clip;
            audioData.Play();
            GameObject canonball = Instantiate(projectile, transform.position,
                                                     transform.rotation);
            canonball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                 (0, launchVelocity, 0));
            
        }
        
    }
}
