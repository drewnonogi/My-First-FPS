using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private Transform gunEndPoint;
    [SerializeField] private GameObject bulletPrefab;
    private float shotForce = 1500f;
    private float weaponSpread = 0.1f;
    private float fireRate = 0.1f;
    private float fireTimer = 0f;

    private void Start()
    {
        shotForce = weaponSO.shotForce;
        weaponSpread = weaponSO.weaponSpread;
        fireRate = weaponSO.fireRate;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && fireTimer >= fireRate)
        {
            Shot();
        }
        fireTimer += Time.deltaTime;

    }

    private void Shot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunEndPoint.position, gunEndPoint.rotation);
        bullet.transform.Rotate(90f, 0f, 0f, Space.Self);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        Vector3 inaccuracySeed = new Vector3(
            Random.Range(-weaponSpread, weaponSpread),
            Random.Range(-weaponSpread, weaponSpread),
            Random.Range(-weaponSpread, weaponSpread)
            );

        bulletRigidbody.AddForce((gunEndPoint.forward + inaccuracySeed) * shotForce);


        Destroy(bullet, 3);

        fireTimer = 0;
    }
}
