using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obsLow;
    public GameObject[] obsHigh;
    public Transform[] spawnPoints;

    public float maxObslowDelay;
    public float curObslowDelay;
    public float maxObshighDelay;
    public float curObshighDelay;

    void Update()
    {
        curObslowDelay += Time.deltaTime;
        curObshighDelay += Time.deltaTime;

        if(curObslowDelay > maxObslowDelay){
            SpawnObsLow();
            maxObslowDelay = Random.Range(2f, 4f);
            curObslowDelay = 0;
        }

        if(curObshighDelay > maxObshighDelay){
            SpawnObsHigh();
            maxObshighDelay = Random.Range(3f, 5f);
            curObshighDelay = 0;
        }
    }

    void SpawnObsLow()
    {
        int ranObs = Random.Range(0, 2);
        Instantiate(obsLow[ranObs], spawnPoints[0].position, spawnPoints[0].rotation);
    }

    void SpawnObsHigh()
    {
        int ranObs = Random.Range(0, 2);
        Instantiate(obsHigh[ranObs], spawnPoints[1].position, spawnPoints[1].rotation);
    }
}
