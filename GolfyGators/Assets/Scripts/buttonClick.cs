using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour
{
    public Button startButton;
    
    // Start is called before the first frame update
    void Start(){
        startButton.onClick.AddListener(changeScene);
    }

    void changeScene(){
        SceneManager.LoadScene("mainGame", LoadSceneMode.Single);
    }
}
