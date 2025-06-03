using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject gunManager;
    [SerializeField] private WeaponSO[] weaponsSO;
    private int SelectedWeapon = 0;



    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        WeaponSwitching();

    }
    private void WeaponSwitching()
    {
        int previousSelectedWeapon = SelectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (SelectedWeapon >= transform.childCount)
            {
                SelectedWeapon = 0;
            }
            else
            {
                SelectedWeapon++;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedWeapon <= 0)
            {
                SelectedWeapon = transform.childCount;
            }
            else
            {
                SelectedWeapon--;
            }

        }
        if (previousSelectedWeapon != SelectedWeapon)
        {
            SelectWeapon();
        }
    }
    private void ClearGunManager()
    {
        //List<Transform> weapons = new List<Transform>();
        for (int i = 0; i < gunManager.transform.childCount; i++)
        {
            Destroy(gunManager.transform.GetChild(i).gameObject);

        }
    }
    private void SelectWeapon()
    {
        ClearGunManager();
        for (int i = 0; i < weaponsSO.Length; i++)
        {
            if (i == SelectedWeapon)
            {
                Instantiate(weaponsSO[i].prefab, gunManager.transform);
            }
        }
    }
}
