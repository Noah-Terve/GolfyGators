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
    
    // add score
    public void addScore(int points) {
        score += points;
        updateScore();
    }

    // remove score
    public void loseScore() {
        score /= 2;
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
