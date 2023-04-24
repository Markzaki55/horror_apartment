using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed = 20f;
    private PickupableObject pickableObject;


    private void Start()
    {
         pickableObject = GetComponent<PickupableObject>();

        if (bulletSpawnPoint == null)
        {
            bulletSpawnPoint = transform;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&pickableObject.isHeld)
        {
            Fire();
        }
    }

    private void Fire()
    {
        SoundManager.PlaySound("Pistol");
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, 5f);

       
        
    }
}