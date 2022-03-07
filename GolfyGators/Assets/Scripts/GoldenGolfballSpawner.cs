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
          public float spawnRangeStart = 0.5f;
          public float spawnRangeEnd = 100f;
          private float timeToSpawn;
          private float spawnTimer = 0f;
          private bool spawned = false;


          void Start() 
          {
              rangeEnd = spawnPoints.Length - 1;
          }
          
          void FixedUpdateG(){
                timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
                spawnTimer += 0.01f;
                if (spawnTimer >= timeToSpawn && spawned == false){
                      spawnGBall();
                      spawnTimer =0f;
                      spawned = true;

                }
          }

          void spawnGBall(){
                int SPnum = Random.Range(0, rangeEnd);
                spawnPoint = spawnPoints[SPnum];
                Instantiate(goldGolfballPrefab, spawnPoint.position, Quaternion.identity);
          }
}
