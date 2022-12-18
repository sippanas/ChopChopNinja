using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon Instance;

    [SerializeField]
    private GameObject _baseWeapon;

    private GameObject _playerWeapon = null;

    // Use this as a getter to receive player selected weapon
    public GameObject PlayerWeapon
    {
        get { return _playerWeapon; }
        private set { _playerWeapon = value; }
    }

    public void SetWeapon(GameObject weapon) => PlayerWeapon = weapon;

    void Start() 
    {
        _playerWeapon = _baseWeapon;
    }

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
