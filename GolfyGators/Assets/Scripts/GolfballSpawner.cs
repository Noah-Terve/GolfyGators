using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfballSpawner : MonoBehaviour
{
    //Object variables
          public GameObject golfballPrefab;
          public Transform[] spawnPoints;
          private int rangeEnd;
          private Transform spawnPoint; 

          //Timing variables
          public float spawnRangeStart = 0.5f;
          public float spawnRangeEnd = 100f;
          private float timeToSpawn;
          private float spawnTimer = 0f;


          void Start() 
          {
              rangeEnd = spawnPoints.Length - 1;
          }
          
          void FixedUpdate(){
                timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
                spawnTimer += 0.01f;
                if (spawnTimer >= timeToSpawn){
                      spawnBall();
                      spawnTimer =0f;
                }
          }

          void spawnBall(){
                int SPnum = Random.Range(0, rangeEnd);
                spawnPoint = spawnPoints[SPnum];
                Instantiate(golfballPrefab, spawnPoint.position, Quaternion.identity);
          }
}
