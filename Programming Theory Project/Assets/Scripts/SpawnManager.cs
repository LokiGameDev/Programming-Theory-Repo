using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private int waveNumber;
    private float xSpawnRange=50f , zSpawnRange=50f;
    private PlayerController playerController;
    void Start()
    {
        waveNumber = 1;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length==0 && playerController.isPlayerAlive)
        {
            SpawnWaveEnemy(waveNumber);
            waveNumber++;
        }
    }

    private Vector3 RandomPosGenerator()
    {
        float xSpawnPos = Random.Range(-xSpawnRange,xSpawnRange);
        float zSpawnPos = Random.Range(-zSpawnRange,zSpawnRange);

        xSpawnPos = xSpawnPos<0 ? xSpawnPos-20 : xSpawnPos+20;
        zSpawnPos = zSpawnPos<0 ? zSpawnPos-20 : zSpawnPos+20;

        Vector3 randomPos = new Vector3(xSpawnPos, 2 , zSpawnPos);

        return randomPos;
    }
    private void SpawnWaveEnemy(int waveCount)
    {
        for(int i=0;i<waveCount;i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex] , RandomPosGenerator() , enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
}
