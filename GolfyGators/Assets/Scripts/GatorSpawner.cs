using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gatorPrefab;
    private float verMax;
    private float verMin;
    private int rangeEnd;
    private Transform spawnPoint;
    public float spawnRangeStart = 1.0f;
    public float spawnRangeEnd = 3.0f;
    private float timeToSpawn;
    private float randomTimer = 0f;
    private float bottomTimer = 0f;
    public float bottomTime = 5f;

    void Start(){
        //gets the top and bottom edges of the screen
        verMax = Camera.main.orthographicSize;
        verMin = -Camera.main.orthographicSize;
      }

      void FixedUpdate(){
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
            randomTimer += 0.01f;
            bottomTimer += 0.01f;
            //spawns the gator to clean the bottom every 5 seconds
            if (bottomTimer >= bottomTime) {
                Debug.Log("Bottom gator made\n");
                spawnGator(verMin);
                bottomTimer = 0f;
                randomTimer = 0f;
            }
            //spawns a gator somewhere if a randomly determined period of time 
            //has passed
            if (randomTimer >= timeToSpawn){
                spawnGator();
                randomTimer = 0f;
            }
            

      }

      void spawnGator(){
            //spawns a gator with a random height to the right of the screen
            spawnGator(Random.Range(verMin, verMax -0.5f));
      }
      void spawnGator(float height){
            //spawns a gator with a height of height to the right of the screen
            Vector3 spawn = new Vector3(12.35f, height, 0);
            Instantiate(gatorPrefab, spawn, Quaternion.identity);
      }
}
