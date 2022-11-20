using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this class for gameplay statistics such as level ending, points and so on
public class GameStatsManager : MonoBehaviour
{
    public static GameStatsManager Instance;

    #region Private fields
    private float _totalTimeElapsed = 0f;
    private int _pointsCollected = 0;
    #endregion

    #region Public fields
    public float TotalTimeElapsed 
    {
        get { return _totalTimeElapsed; }
        private set { _totalTimeElapsed = value; }
    }

    public int PointsCollected
    {
        get { return _pointsCollected; }
        private set { _pointsCollected = value; }
    }
    #endregion

    public void AddPoints(int points) => PointsCollected += points;

    void Update()
    {
        TotalTimeElapsed += Time.deltaTime;
    }

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
