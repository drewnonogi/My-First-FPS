using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponSO : ScriptableObject
{
    public string gunName;
    public Transform prefab;
    public float shotForce;
    public float weaponSpread;
    public float fireRate;
}
