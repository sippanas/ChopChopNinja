using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonballLauncher : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> cannons;
    [SerializeField]
    public GameObject projectile;
    [SerializeField]
    public float launchVelocity = 1000f;
    [SerializeField]
    AudioClip clip;

    float elapsed = 0;

    int difficultyIndex = (int)DifficultyLevels.EASY;
    float baseTimeToElapse = 1.5f;
    float timeBasedOnDifficulty = 0f;

    void Start()
    {
        difficultyIndex = DifficultyManager.Instance.CurrentDifficultyIndex;
        if(difficultyIndex != (int)DifficultyLevels.DYNAMIC) timeBasedOnDifficulty = (float)difficultyIndex;
    }

    void Update()
    {
        if(difficultyIndex == (int)DifficultyLevels.DYNAMIC)
        {
            float totalTimeElapsed = GameStatsManager.Instance.TotalTimeElapsed;
            timeBasedOnDifficulty = Mathf.Floor(totalTimeElapsed / 30f);
        }

        elapsed += Time.deltaTime;
        var timeToElapse = (baseTimeToElapse - (timeBasedOnDifficulty / 10f));

        if (elapsed >= Mathf.Clamp(timeToElapse, 0.1f, baseTimeToElapse))
        {
            elapsed = elapsed % timeToElapse;
            Shoot(cannons[Random.Range(0, cannons.Count)]);
            //StartCoroutine(Pattern1()); //use at your own risk
        }
        
    }
    void Shoot(GameObject cannon)
    {
        AudioSource audio = cannon.GetComponentInParent<AudioSource>();
        audio.Play();
        GameObject canonball = Instantiate(projectile, cannon.transform.position,
                                                     cannon.transform.rotation);
        canonball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                             (0, launchVelocity + Random.Range(-5f, 5f), 0));
    }
    IEnumerator Pattern1()
    {
        Shoot(cannons[0]);
        yield return new WaitForSeconds(0.3f);
        Shoot(cannons[1]);
        yield return new WaitForSeconds(0.3f);
        Shoot(cannons[2]);
        yield return new WaitForSeconds(0.3f);
        Shoot(cannons[3]);
    }
}
