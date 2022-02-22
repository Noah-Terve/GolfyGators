using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorSpawner : MonoBehaviour
{
    // Start is called before the first frame update
      public GameObject gatorPrefab;

      private int rangeEnd;
      private Transform spawnPoint;

      //public GameObject gameOverText;

      public float spawnRangeStart = 0.5f;
      public float spawnRangeEnd = 2.5f;
      private float timeToSpawn;
      private float spawnTimer = 0f;

      void Start(){

      }

      void FixedUpdate(){
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
            spawnTimer += 0.01f;
            if (spawnTimer >= timeToSpawn){
                  spawnGator();
                  spawnTimer = 0f;
            }
      }

      void spawnGator(){
            //better way to spawn gators
            Vector3 spawn = new Vector3(12.35f, Random.Range(-4f,4f), 0);
            Instantiate(gatorPrefab, spawn, Quaternion.identity);
      }
}
