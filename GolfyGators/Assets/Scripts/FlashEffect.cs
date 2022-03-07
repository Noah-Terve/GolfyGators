using UnityEngine;
using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    public Text message;
    
    public Color green => Color.green;
    public Color yellow => Color.yellow;
    
    public void Update()
    {
        message.color = Flash();
    }
    
    public Color Flash()
    {
        return Color.Lerp(green, yellow, Mathf.Sin(Time.time));
    }
}
