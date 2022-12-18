using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static ComboManager instance;
    public int comboMultiplier = 1;
    public int lives = 1;
    public int toSlice = 10;
    void Awake()
    {
        instance = this;
    }
    public void Slice()
    {
        GameManager.Instance.AddPoints((100 + (ModifierManager.instance.dullBlade ? 25 : 0) + (ModifierManager.instance.tinyCanonballs ? 20 : 0)) * comboMultiplier);
        Debug.Log((100 + (ModifierManager.instance.dullBlade ? 25 : 0) + (ModifierManager.instance.tinyCanonballs ? 20 : 0)) * comboMultiplier);
        comboMultiplier++;
        if(lives == 0)
        {
            toSlice--;
        }
        if(toSlice == 0)
        {
            lives = 1;
        }
    }
    public void Miss()
    {
        if (lives == 1)
        {
            lives = 0;
            comboMultiplier = 1;
            toSlice = 10;
        }
        else GameManager.Instance.EndGame();
        
    }
}
