using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bulletPrefab;

    public Transform muzzlePoint;

    public void Shot(Vector3 direction)
    {
        GameObject bulletGO = Instantiate(bulletPrefab.gameObject);
        bulletGO.GetComponent<Bullet>().Setup(this);
        bulletGO.transform.position = muzzlePoint.position;
        bulletGO.transform.rotation = muzzlePoint.rotation;
    }

}
