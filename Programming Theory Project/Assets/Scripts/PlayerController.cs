using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float speed = 10;
    private bool canShoot = true;
    private float yDeg;
    public float lives
    {
        get; private set;
    }
    public bool isPlayerAlive
    {
        get; private set;
    }
    public float score
    {
        get; private set;
    }
    void Start()
    {
        isPlayerAlive = true;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
        if(isPlayerAlive)
        {
            PlayerMovement();
            PlayerRotation();
        }
    }


    private void PlayerMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }
    private void PlayerRotation()
    {
        yDeg += Input.GetAxis("Mouse X") * 5 * 1;
        transform.rotation = Quaternion.Lerp(transform.rotation , Quaternion.Euler(0 , yDeg , 0) , Time.deltaTime * 5);

    }
    public void PlayerDamage()
    {
        lives-=1;
        if(lives==0){
            isPlayerAlive=false;
        }
    }

    private void ShootBullet()
    {
        if(canShoot)
        {
            Instantiate(bulletPrefab , transform.position , bulletPrefab.transform.rotation);
            canShoot = false;
            StartCoroutine(BulletReloadCoolDown());
        }
    }
    IEnumerator BulletReloadCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    public void AddScore()
    {
        score += 5;
    }
}
