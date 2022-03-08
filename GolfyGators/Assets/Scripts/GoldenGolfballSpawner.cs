using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenGolfballSpawner : MonoBehaviour
{
    //Object variables
          public GameObject goldGolfballPrefab;
          public Transform[] spawnPoints;
          private int rangeEnd;
          private Transform spawnPoint; 

          //Timing variables
          private int spawnRangeStart = 1000; // 20 seconds
          private int spawnRangeEnd = 6000; // 2 minutes
          private float timeToSpawn;
          private int spawnTimer = 0;
          private bool spawned = false;


          void Start()
          {
              rangeEnd = spawnPoints.Length - 1;
          }
          
          void FixedUpdate(){
                timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
                spawnTimer += 1;
                if (spawnTimer >= timeToSpawn && spawned == false){
                      spawnGBall();
                      spawnTimer = 0;
                      spawned = true;
                      Debug.Log("golden ball if ran\n");
                }
          }

          void spawnGBall(){
                int SPnum = Random.Range(0, rangeEnd);
                spawnPoint = spawnPoints[SPnum];
                Instantiate(goldGolfballPrefab, spawnPoint.position, Quaternion.identity);
          }
}
