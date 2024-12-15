using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public virtual void FollowPlayer()
    {
        player = GameObject.Find("Player");
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,0.01f);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().PlayerDamage();
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().AddScore();
            Destroy(gameObject);
        }
    }
}
