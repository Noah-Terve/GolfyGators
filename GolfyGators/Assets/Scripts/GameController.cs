using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject scoreText;
    public int score = 0;
    
    // Start is called before the first frame update
    void Start() {
        // update the score
        updateScore();
    }
    
    // Update to get called every frame
    void Update() {
        if (Input.GetKey("escape")){
                SceneManager.LoadScene("startMenu", LoadSceneMode.Single);
        }
    }
    
    // add score
    public void addScore(int points) {
        score += points;
        updateScore();
    }

    // remove score
    public void loseScore() {
        if (score > 0)
            score--;
        updateScore();
    }
    
    // update the score
    void updateScore() {
        Text scoreTextB = scoreText.GetComponent<Text>();
        scoreTextB.text = "" + score;
        if (score > 10) {
            SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
        }
    }
}
