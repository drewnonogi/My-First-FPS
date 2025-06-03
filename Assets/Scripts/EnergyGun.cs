using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGun : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private Transform gunEndPoint;
    [SerializeField] private GameObject bulletPrefab;
    private float bulletSpeed = 1f;
    private float weaponSpread = 0.1f;
    private float fireRate = 0.1f;
    private float fireTimer = 0f;

    private LineRenderer lineRenderer;
    private float maxLaserDistance = 1000f;



    private void Start()
    {
        bulletSpeed = weaponSO.shotForce;
        weaponSpread = weaponSO.weaponSpread;
        fireRate = weaponSO.fireRate;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && fireTimer >= fireRate)
        {
            Shot();
        }
        fireTimer += Time.deltaTime;

        DrawRay();

    }

    private void DrawRay()
    {
        RaycastHit hit;
        Vector3 laserEndPoint;

        if (Physics.Raycast(this.gunEndPoint.position, this.gunEndPoint.forward, out hit, maxLaserDistance))
        {
            laserEndPoint = hit.point;
        }
        else
        {
            laserEndPoint = gunEndPoint.position + gunEndPoint.forward * maxLaserDistance;
        }

        lineRenderer.SetPosition(0, gunEndPoint.position);
        lineRenderer.SetPosition(1, laserEndPoint);
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

        bulletRigidbody.useGravity = false;
        bulletRigidbody.velocity = (gunEndPoint.forward + inaccuracySeed) * bulletSpeed;


        Destroy(bullet, 30);

        fireTimer = 0;
    }
}
