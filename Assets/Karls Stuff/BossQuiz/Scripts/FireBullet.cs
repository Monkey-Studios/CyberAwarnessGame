using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public Transform firePoint; // ref to the firepoint
    public GameObject bulletPrefab;
    // Update is called once per frame

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // instantiate spell from position of fire point and rotation of fire point
    }
}
