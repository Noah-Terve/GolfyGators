using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndText : MonoBehaviour
{
    
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.color = Color.white;
        StartCoroutine(Yield());
        text.color = Color.blue;
        StartCoroutine(Yield());
        text.color = Color.yellow;
        StartCoroutine(Yield());
        text.color = Color.green;
        StartCoroutine(Yield());
        
    }
    
    IEnumerator Yield()
    {
        yield return new WaitForSeconds(5);
    }
}
