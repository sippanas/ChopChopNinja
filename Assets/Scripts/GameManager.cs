using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool GameHasEnded = false;

    #region Private fields
    private float _totalTimeElapsed = 0f;
    private int _pointsCollected = 0;
    private int _objectsSliced = 0;
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
    
    public int ObjectsSliced 
    {
        get { return _objectsSliced; }
        private set { _objectsSliced = value; }
    }
    #endregion

    [SerializeField]
    private GameObject GameEndCanvas;

    [SerializeField]
    private TextMeshProUGUI TimeSpentPlayingText;

    [SerializeField]
    private TextMeshProUGUI ObjectsSlicedText;

    public void AddPoints(int points) => PointsCollected += points;
    public void AddObjectSliced() => ObjectsSliced ++;

    public void EndGame()
    {
        Time.timeScale = 0;
        GameHasEnded = true;

        var elapsedInt = (int)TotalTimeElapsed;
        var minutes = Mathf.Floor(elapsedInt / 60);
        var seconds = Mathf.RoundToInt(elapsedInt % 60);

        TimeSpentPlayingText.text = $"{minutes} min {seconds} sec";
        ObjectsSlicedText.text = $"{ObjectsSliced}";

        GameEndCanvas.SetActive(true);
        foreach(var obj in GameObject.FindGameObjectsWithTag("DontDestroyOnLoad"))
        {
            Destroy(obj);
        }
    }

    void Start()
    {
        Time.timeScale = 1; // Unpause the scene (could be previously paused by game end)
        GameHasEnded = false;
    }

    void Update()
    {
        if(!GameHasEnded) TotalTimeElapsed += Time.deltaTime;
    }

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
