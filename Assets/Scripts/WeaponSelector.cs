using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSelector : MonoBehaviour
{
    [Header("Weapon names and prefabs")]
    [SerializeField]
    private List<string> weaponNames;

    [SerializeField]
    private List<GameObject> weapons;

    [Header("References")]
    [SerializeField]
    private TextMeshProUGUI weaponNameText;

    private int index;

    void Start()
    { 
        index = 0;
        ShowWeapon(index);
    }

    public void Previous()
    {
        if(index - 1 > -1)
        {
            index --;
        }
        else 
        {
            index = 0;
        }

        ShowWeapon(index);
    }

    public void Next() 
    {
        if(index + 1 < weapons.Count)
        {
            index ++;
        }
        else 
        {
            index = 0;
        }

        ShowWeapon(index);
    }

    private void ShowWeapon(int index)
    {
        if(this.transform.GetChild(1).gameObject.activeSelf)
        {
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(0).gameObject.SetActive(true);
            weaponNameText.text = "Katana";
        }
        else
        {
            
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
            weaponNameText.text = "Comically large sword";
        }
        /*// Save transform values
        Transform transformValues = this.transform.GetChild(0).transform;

        // Removes the previous weapon
        Destroy(this.transform.GetChild(0).gameObject);

        var instantiateWeapon = Instantiate(weapons.ElementAt(index), transformValues);
        instantiateWeapon.transform.SetParent(this.transform);
       // instantiateWeapon.transform = new Vector3(0, -10, -35);
        //instantiateWeapon.transform.SetPositionAndRotation(new Vector3(0, -10, -35), new Quaternion(90, 0, -90, 0));

        if (weaponNames.ElementAt(index) != null)
        {
            weaponNameText.text = $"{weaponNames.ElementAt(index)}";
        }
        else
        {
            weaponNameText.text = $"Weapon {index}";
        }*/
    }

    public void SelectWeapon()
    {
        Weapon.Instance.SetWeapon(weapons.ElementAt(index));
    }
}
