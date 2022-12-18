using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    public static ModifierManager instance;
    public bool dullBlade = false;
    public bool tinyCanonballs = false;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleDullBlade(bool value)
    {
        dullBlade = value;
    }
    public void ToggleTinyCanonballs(bool value)
    {
        tinyCanonballs = value;
    }
}
