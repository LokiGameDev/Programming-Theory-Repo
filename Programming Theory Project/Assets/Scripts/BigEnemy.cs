using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    public GameObject bulletPrefab;
    private bool canShootBullet = true;
    void Start()
    {
        
    }

    void Update()
    {
        FollowPlayer();
    }

    public override void FollowPlayer()
    {
        if(canShootBullet)
        {
            ShootBullet();
        }
        base.FollowPlayer();
    }

    private void ShootBullet()
    {
        Vector3 bulletSpawnPos = new Vector3(transform.position.x , transform.position.y , transform.position.z + 2);
        Instantiate(bulletPrefab , bulletSpawnPos , bulletPrefab.transform.rotation);
        canShootBullet=false;
        StartCoroutine(BulletCoolDown());
    }
    IEnumerator BulletCoolDown()
    {
        yield return new WaitForSeconds(3);
        canShootBullet = true;
    }
}
