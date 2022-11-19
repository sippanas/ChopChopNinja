using System;
using System.Linq;
using UnityEngine;
using TMPro;

public enum DifficultyLevels 
{
    EASY,
    NORMAL,
    HARD,
    DYNAMIC
}

public class DifficultyManager : MonoBehaviour
{
    // Using a singleton instance to make sure we have the same instance between scenes
    public static DifficultyManager Instance;

    [SerializeField]
    private TextMeshProUGUI DifficultyText;

    private int _currentDifficultyIndex = (int)DifficultyLevels.EASY;
    public int CurrentDifficultyIndex 
    {
        get { return _currentDifficultyIndex; }
        private set { _currentDifficultyIndex = value; }
    }

    private int firstDifficultyIndex = (int)Enum.GetValues(typeof(DifficultyLevels)).Cast<DifficultyLevels>().Min();
    private int lastDifficultyIndex = (int)Enum.GetValues(typeof(DifficultyLevels)).Cast<DifficultyLevels>().Max();

    // If 'next' is true, means that the player is pressing "next" button (>)
    // If 'next' is false, means that a player is pressing "previous" button (<)
    public void SwitchDifficultyLevel(bool next)
    {
        if(next)
        {
            if(CurrentDifficultyIndex == lastDifficultyIndex)
            {
                CurrentDifficultyIndex = firstDifficultyIndex;
            }
            else CurrentDifficultyIndex ++;
        }
        else
        {
            if(CurrentDifficultyIndex == firstDifficultyIndex)
            {
                CurrentDifficultyIndex = lastDifficultyIndex;
            } 
            else CurrentDifficultyIndex --;
        }

        var CurrentDifficultyText = Enum.GetValues(typeof(DifficultyLevels)).Cast<DifficultyLevels>().ElementAt(CurrentDifficultyIndex);
        DifficultyText.text = $"Difficulty: {CurrentDifficultyText}";
    }

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
