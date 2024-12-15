using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5);
        transform.LookAt(GameObject.Find("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 15 * Time.deltaTime);
    }
}
